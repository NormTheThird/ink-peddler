using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using InkPeddler.GraphQL.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace InkPeddler.GraphQL.API.Schema.Types
{
    public class AccountType : ObjectType<Account>
    {
        protected override void Configure(IObjectTypeDescriptor<Account> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(_ => _.Id).Type<NonNullType<IdType>>();
            descriptor.Field(t => t.AddressId).Ignore();
            descriptor.Field(_ => _.AwsprofileImageId).Ignore();
            descriptor.Field(_ => _.FirstName).Type<NonNullType<StringType>>();
            descriptor.Field(_ => _.LastName).Type<NonNullType<StringType>>();
            descriptor.Field(_ => _.Email).Type<NonNullType<StringType>>();
            descriptor.Field(_ => _.PhoneNumber).Type<NonNullType<StringType>>();
            descriptor.Field(_ => _.WebsiteUrl).Type<NonNullType<StringType>>();
            descriptor.Field(_ => _.FacebookUrl).Type<NonNullType<StringType>>();
            descriptor.Field(_ => _.InstagramUrl).Type<NonNullType<StringType>>();
            descriptor.Field(_ => _.TwitterUrl).Type<NonNullType<StringType>>();
            descriptor.Field(_ => _.AllowedOrigin).Ignore();
            descriptor.Field(_ => _.RefreshTokenLifeTimeMinutes).Ignore();
            descriptor.Field(_ => _.Password).Ignore();
            descriptor.Field(_ => _.IsSystemAdmin).Type<NonNullType<BooleanType>>();
            descriptor.Field(_ => _.IsActive).Type<NonNullType<BooleanType>>();
            descriptor.Field(_ => _.IsArtist).Type<NonNullType<BooleanType>>();

            descriptor.Field<AccountType>(_ => _.ResolveAddress(default, default, default))
                .Description("Address associated with the account")
                .Name("address")
                .Type<NonNullType<AddressType>>();
        }

        public async Task<Address> ResolveAddress(IResolverContext context, [Parent] Account account, [Service] InkPeddlerContext dbContext)
        {
            var dataLoader = context.BatchDataLoader<Guid, Address>(nameof(ResolveAddress), async addressIds =>
                await dbContext.Address.Where(_ => addressIds.Contains(_.Id)).ToDictionaryAsync(_ => _.Id, _ => _));
            return await dataLoader.LoadAsync(account.AddressId, context.RequestAborted);
        }
    }
}
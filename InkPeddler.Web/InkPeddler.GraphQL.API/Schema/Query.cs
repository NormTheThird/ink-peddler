using HotChocolate;
using InkPeddler.GraphQL.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InkPeddler.GraphQL.API.Schema
{
    public class Query
    {
        public async Task<IReadOnlyList<Account>> GetAccounts([Service] InkPeddlerContext dbContext)
        {
            return await dbContext.Account.OrderByDescending(_ => _.DateCreated).ToListAsync();

        }

        public async Task<IReadOnlyList<Account>> GetAccountsPaging([Service] InkPeddlerContext dbContext)
        {
            return await dbContext.Account.OrderByDescending(_ => _.DateCreated).ToListAsync();

        }

        public Task<Account> GetAccount([Service] InkPeddlerContext dbContext, Guid id) => dbContext.Account.FindAsync(id);
    }
}
using System;
using AutoMapper;
using InkPeddler.Common.Models;
using InkPeddler.Data;
using System.Collections.Generic;
using System.Linq;
using GoogleMaps.LocationServices;

namespace InkPeddler.Services
{
    public interface IMapperService
    {
        List<T> MapToList<U, T>(IQueryable<U> _source);
        T Map<U, T>(U source);
        T Map<U, T>(U source, T destination);
    }

    public class MapperService : IMapperService
    {
        public List<T> MapToList<U, T>(IQueryable<U> _source)
        {
            try
            {
                var lst = new List<T>();
                foreach (var item in _source)
                {
                    var model = Map<U, T>(item);
                    if (model != null) lst.Add(model);
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T Map<U, T>(U source)
        {
            try
            {
                var mapper = CreateMap<U, T>();
                return mapper.Map<U, T>(source);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T Map<U, T>(U source, T destination)
        {
            try
            {
                var mapper = CreateMap<U, T>();
                return mapper.Map<U, T>(source, destination);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static IMapper CreateMap<U, T>()
        {
            // Account Mappings
            if (typeof(U) == typeof(Account) && typeof(T) == typeof(AccountModel))
                return MapAccountToAccountModel().CreateMapper();
            else if (typeof(U) == typeof(AccountModel) && typeof(T) == typeof(Account))
                return MapAccountModelToAccount().CreateMapper();
            if (typeof(U) == typeof(AccountRefreshToken) && typeof(T) == typeof(RefreshTokenModel))
                return MapAAccountRefreshTokenToRefreshTokenModel().CreateMapper();

            // Address Mappings
            else if (typeof(U) == typeof(AddressModel) && typeof(T) == typeof(AddressData))
                return MapAddressModelToAddressData().CreateMapper();

            // Business Mappings
            else if(typeof(U) == typeof(Business) && typeof(T) == typeof(BusinessModel))
                return MapBusinessToBusinessModel().CreateMapper();
            else if (typeof(U) == typeof(BusinessModel) && typeof(T) == typeof(Business))
                return MapBusinessModelToBusiness().CreateMapper();

            // Tattoo Mappings
            else if(typeof(U) == typeof(Tattoo) && typeof(T) == typeof(TattooModel))
                return MapTattooToTattooModel().CreateMapper();
            else if (typeof(U) == typeof(TattooModel) && typeof(T) == typeof(Tattoo))
                return MapTattooModelToTattoo().CreateMapper();
            else if (typeof(U) == typeof(TattooComment) && typeof(T) == typeof(TattooCommentModel))
                return MapTattooCommentToTattooCommentModel().CreateMapper();
            else if (typeof(U) == typeof(TattooCommentModel) && typeof(T) == typeof(TattooComment))
                return MapTattooCommentModelToTattooComment().CreateMapper();

            // Style Mappings
            else if (typeof(U) == typeof(Style) && typeof(T) == typeof(StyleModel))
                return MapStyleToStyleModel().CreateMapper();
            else if (typeof(U) == typeof(StyleModel) && typeof(T) == typeof(Style))
                return MapStyleModelToStyle().CreateMapper();

            else
                throw new ApplicationException("No mapping congiuration exists [" + typeof(T).ToString() + "]");
        }

        // Account Mappings
        private static MapperConfiguration MapAccountToAccountModel()
        {
            return new MapperConfiguration(config =>
            {
                config.CreateMap<Address, AddressModel>();
                config.CreateMap<Account, AccountModel>();
            });
        }
        private static MapperConfiguration MapAccountModelToAccount()
        {
            return new MapperConfiguration(config =>
            {
                config.CreateMap<AddressModel, Address>()
                      .ForMember(dest => dest.Id, opt => opt.Ignore())
                      .ForMember(dest => dest.Address2, opt => opt.MapFrom(src => src.Address2 ?? ""))
                      .ForMember(dest => dest.DateCreated, opt => opt.Ignore());
                config.CreateMap<AccountModel, Account>()
                      .ForMember(dest => dest.Id, opt => opt.Ignore())
                      .ForMember(dest => dest.AddressId, opt => opt.Ignore())
                      .ForMember(dest => dest.Password, opt => opt.Ignore())
                      .ForMember(dest => dest.DateCreated, opt => opt.Ignore());
            });
        }
        private static MapperConfiguration MapAAccountRefreshTokenToRefreshTokenModel()
        {
            return new MapperConfiguration(config =>
            {
                config.CreateMap<AccountRefreshToken, RefreshTokenModel>();
            });
        }

        // Address Mappings
        private static MapperConfiguration MapAddressModelToAddressData()
        {
            return new MapperConfiguration(config => config.CreateMap<AddressModel, AddressData>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => (src.Address1 + " " + src.Address2 ?? "").Trim()))
                .ForMember(dest => dest.Zip, opt => opt.MapFrom(src => src.ZipCode)));
        }

        // Business Mappings
        private static MapperConfiguration MapBusinessToBusinessModel()
        {
            return new MapperConfiguration(config =>
            {
                config.CreateMap<Address, AddressModel>();
                config.CreateMap<Business, BusinessModel>();
            });
        }
        private static MapperConfiguration MapBusinessModelToBusiness()
        {
            return new MapperConfiguration(config =>
            {
                config.CreateMap<AddressModel, Address>()
                      .ForMember(dest => dest.Id, opt => opt.Ignore())
                      .ForMember(dest => dest.Address2, opt => opt.MapFrom(src => src.Address2 ?? ""))
                      .ForMember(dest => dest.DateCreated, opt => opt.Ignore());
                config.CreateMap<BusinessModel, Business>()
                      .ForMember(dest => dest.Id, opt => opt.Ignore())
                      .ForMember(dest => dest.AddressId, opt => opt.Ignore())
                      .ForMember(dest => dest.FacebookUrl, opt => opt.MapFrom(src => src.FacebookUrl ?? ""))
                      .ForMember(dest => dest.TwitterUrl, opt => opt.MapFrom(src => src.TwitterUrl ?? ""))
                      .ForMember(dest => dest.InstagramUrl, opt => opt.MapFrom(src => src.InstagramUrl ?? ""))
                      .ForMember(dest => dest.WebsiteUrl, opt => opt.MapFrom(src => src.WebsiteUrl ?? ""))
                      .ForMember(dest => dest.DateCreated, opt => opt.Ignore());
            });
        }

        // Tattoo Mappings
        private static MapperConfiguration MapTattooToTattooModel()
        {
            return new MapperConfiguration(config => config.CreateMap<Tattoo, TattooModel>());
        }
        private static MapperConfiguration MapTattooModelToTattoo()
        {
            return new MapperConfiguration(config => config.CreateMap<TattooModel, Tattoo>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.UploadedByAccountId, opt => opt.Ignore())
                .ForMember(dest => dest.DateCreated, opt => opt.Ignore()));
        }
        private static MapperConfiguration MapTattooCommentToTattooCommentModel()
        {
            return new MapperConfiguration(config => config.CreateMap<TattooComment, TattooCommentModel>());
        }
        private static MapperConfiguration MapTattooCommentModelToTattooComment()
        {
            return new MapperConfiguration(config => config.CreateMap<TattooCommentModel, TattooComment>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TattooId, opt => opt.Ignore())
                .ForMember(dest => dest.AccountId, opt => opt.Ignore())
                .ForMember(dest => dest.DateCreated, opt => opt.Ignore()));
        }

        // Style Mappings
        private static MapperConfiguration MapStyleToStyleModel()
        {
            return new MapperConfiguration(config => config.CreateMap<Style, StyleModel>());
        }
        private static MapperConfiguration MapStyleModelToStyle()
        {
            return new MapperConfiguration(config => config.CreateMap<StyleModel, Style>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.DateCreated, opt => opt.Ignore()));
        }
    }
}
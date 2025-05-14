using System;
using System.Configuration;
using System.Linq;
using GoogleMaps.LocationServices;
using InkPeddler.Common.Models;
using InkPeddler.Common.RequestAndResponses;
using InkPeddler.Data;

namespace InkPeddler.Services
{
    public interface IBusinessService : IBaseService
    {
        GetBusinessesResponse GetBusinesses(GetBusinessesRequest request);
        GetBusinessListResponse GetBusinessList(GetBusinessListRequest request);
        GetBusinessesForLocationResponse GetBusinessesForLocation(GetBusinessesForLocationRequest request);
        GetBusinessLocationsResponse GetBusinessLocations(GetBusinessLocationsRequest request);
        GetBusinessAccountsResponse GetBusinessAccounts(GetBusinessAccountsRequest request);
        GetBusinessAndAccountsResponse GetBusinessAndAccounts(GetBusinessAndAccountsRequest request);
        GetBusinessResponse GetBusiness(GetBusinessRequest request);
        SaveBusinessResponse SaveBusiness(SaveBusinessRequest request);
        SaveBusinessImageResponse SaveBusinessImage(SaveBusinessImageRequest request);
        AddBusinessAccountResponse AddBusinessAccount(AddBusinessAccountRequest request);
        RemoveBusinessAccountResponse RemoveBusinessAccount(RemoveBusinessAccountRequest request);
    }

    public class BusinessService : BaseService, IBusinessService
    {
        public GetBusinessesResponse GetBusinesses(GetBusinessesRequest request)
        {
            try
            {
                var response = new GetBusinessesResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var businesses = context.Businesses.AsNoTracking().Where(b => request.GetActiveAndInactive ? (b.IsActive || !b.IsActive) : b.IsActive)
                                                       .Select(b => new BusinessModel
                                                       {
                                                           Id = b.Id,
                                                           AddressId = b.AddressId,
                                                           AWSProfileImageId = b.AWSProfileImageId,
                                                           Address = new AddressModel
                                                           {
                                                               Id = b.Address.Id,
                                                               Address1 = b.Address.Address1,
                                                               Address2 = b.Address.Address2,
                                                               City = b.Address.City,
                                                               State = b.Address.State,
                                                               ZipCode = b.Address.ZipCode,
                                                               Latitude = b.Address.Latitude,
                                                               Longitude = b.Address.Longitude,
                                                               DateCreated = b.DateCreated
                                                           },
                                                           Name = b.Name,
                                                           RegistrationCode = b.RegistrationCode,
                                                           PhoneNumber = b.PhoneNumber,
                                                           GoogleMapId = b.GoogleMapId,
                                                           GoogleMapPlaceId = b.GoogleMapPlaceId,
                                                           AzureMapsSearchType = b.AzureMapsSearchType,
                                                           AzureMapsSearchId = b.AzureMapsSearchId,
                                                           FacebookUrl = b.FacebookUrl,
                                                           TwitterUrl = b.TwitterUrl,
                                                           WebsiteUrl = b.WebsiteUrl,
                                                           InstagramUrl = b.InstagramUrl,
                                                           IsActive = b.IsActive,
                                                           ValidatedBy = b.ValidatedBy,
                                                           DateLastValidated = b.DateLastValidated,
                                                           DateCreated = b.DateCreated
                                                       });

                    response.Businesses = businesses.ToList();
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new GetBusinessesResponse { ErrorMessage = "Unable to get businesses." };
            }
        }

        public GetBusinessListResponse GetBusinessList(GetBusinessListRequest request)
        {
            try
            {
                var response = new GetBusinessListResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var businesses = context.Businesses.AsNoTracking()
                                            .Where(b => b.IsActive)
                                            .Select(b => new BusinessListModel
                                            {
                                                Id = b.Id,
                                                Name = b.Name,
                                                RegistrationCode = b.RegistrationCode,
                                                CityState = b.Address.City + ", " + b.Address.State
                                            }).OrderBy(b => b.Name);

                    response.Businesses = businesses.ToList();
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new GetBusinessListResponse { ErrorMessage = "Unable to get business list." };
            }
        }

        public GetBusinessesForLocationResponse GetBusinessesForLocation(GetBusinessesForLocationRequest request)
        {
            try
            {
                var response = new GetBusinessesForLocationResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var businesses = context.GetBusinessesForLocation(request.Latitude.ToString(), request.Longitude.ToString(), request.Radius)
                                            .Select(b => new BusinessLocationModel
                                            {
                                                Id = b.Id,
                                                Name = b.Name,
                                                Latitude = b.Latitude,
                                                Longitude = b.Longitude
                                            });
                    response.Businesses = businesses.ToList();
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new GetBusinessesForLocationResponse { ErrorMessage = "Unable to get businesses for location." };
            }
        }

        public GetBusinessLocationsResponse GetBusinessLocations(GetBusinessLocationsRequest request)
        {
            try
            {
                var response = new GetBusinessLocationsResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var businesses = context.Businesses.AsNoTracking()
                                            .Select(b => new BusinessLocationModel
                                            {
                                                Id = b.Id,
                                                Name = b.Name,
                                                Latitude = b.Address.Latitude,
                                                Longitude = b.Address.Longitude
                                            });
                    response.BusinessLocations = businesses.ToList();
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new GetBusinessLocationsResponse { ErrorMessage = "Unable to get business locations." };
            }
        }

        public GetBusinessAccountsResponse GetBusinessAccounts(GetBusinessAccountsRequest request)
        {
            try
            {
                var response = new GetBusinessAccountsResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var xlinkAccounts = context.BusinessAccountCrossLinks.AsNoTracking()
                        .Where(xl => xl.BusinessId == request.BusinessId)
                        .Select(xl => new BusinessAccountModel
                        {
                            BusinessId = xl.BusinessId,
                            AccountId = xl.Account.Id,
                            FirstName = xl.Account.FirstName,
                            LastName = xl.Account.LastName,
                            Email = xl.Account.Email,
                            FullName = xl.Account.FirstName + " " + xl.Account.LastName,
                            PhoneNumber = xl.Account.PhoneNumber,
                            IsActive = xl.Account.IsActive,
                            IsArtist = xl.Account.IsArtist,
                            IsOwner = xl.IsOwner,
                            IsManager = xl.IsManager
                        });
                    response.BusinessAccounts = xlinkAccounts.ToList();
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new GetBusinessAccountsResponse { ErrorMessage = "Unable to get business accounta." };
            }
        }

        public GetBusinessAndAccountsResponse GetBusinessAndAccounts(GetBusinessAndAccountsRequest request)
        {
            try
            {
                var response = new GetBusinessAndAccountsResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var businessAndArtist = context.GetBusinessAndAccounts(request.BusinessId).ToList();

                    var business = businessAndArtist.FirstOrDefault();
                    response.Business = new QuickBusinessModel
                    {
                        Id = business.BusinessId,
                        Name = business.BusinessName,
                        PhoneNumber = business.BusinessPhone,
                        FullAddress = FormatAddress(business.Address1, business.Address2, business.City, business.State,
                            business.ZipCode)
                    };

                    if (business.AccountId != null)
                    {
                        response.Accounts = businessAndArtist.Select(a => new QuickBusinessAccountModel()
                        {
                            AccountId = (Guid)a.AccountId,
                            FullName = a.AccountName,
                            PhoneNumber = a.AccountPhone,
                            IsArtist = (bool)a.IsArtist,
                            IsOwner = (bool)a.IsOwner,
                            IsManager = (bool)a.IsManager
                        }).ToList();
                    }

                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new GetBusinessAndAccountsResponse { ErrorMessage = "Unable to get business and artist." };
            }
        }

        public GetBusinessResponse GetBusiness(GetBusinessRequest request)
        {
            try
            {
                var response = new GetBusinessResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var business = context.Businesses.AsNoTracking().FirstOrDefault(b => b.Id.Equals(request.BusinessId));
                    if (business == null) throw new ApplicationException("Business does not exist for id " + request.BusinessId);
                    response.Business = MapperService.Map<Business, BusinessModel>(business);
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new GetBusinessResponse { ErrorMessage = "Unable to get business." };
            }
        }

        public SaveBusinessResponse SaveBusiness(SaveBusinessRequest request)
        {
            try
            {
                var response = new SaveBusinessResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var business = context.Businesses.FirstOrDefault(b => b.Id.Equals(request.Business.Id));
                    if (business == null)
                    {
                        business = new Business { Id = Guid.NewGuid() };
                        business.Address = new Address { Id = Guid.NewGuid() };
                        business.RegistrationCode = "";
                        context.Businesses.Add(business);
                    }

                    var addressData = MapperService.Map<AddressModel, AddressData>(request.Business.Address);
                    var apiKey = ConfigurationManager.AppSettings["GoogleApiKey"];
                    var points = new GoogleLocationService(apiKey).GetLatLongFromAddress(addressData);
                    request.Business.Address.Latitude = Math.Round(Convert.ToDecimal(points.Latitude), 6, MidpointRounding.ToEven);
                    request.Business.Address.Longitude = Math.Round(Convert.ToDecimal(points.Longitude), 6, MidpointRounding.ToEven);

                    MapperService.Map(request.Business, business);
                    context.SaveChanges();

                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new SaveBusinessResponse() { ErrorMessage = "Unable to save business." };
            }
        }

        public SaveBusinessImageResponse SaveBusinessImage(SaveBusinessImageRequest request)
        {
            try
            {
                var response = new SaveBusinessImageResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var business = context.Businesses.FirstOrDefault(b => b.Id.Equals(request.BusinessId));
                    if (business == null) throw new ApplicationException($"Unable to find business id {request.BusinessId}");
                    business.AWSProfileImageId = request.AWSProfileImageId;
                    context.SaveChanges();
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new SaveBusinessImageResponse() { ErrorMessage = "Unable to save business image." };
            }
        }

        public AddBusinessAccountResponse AddBusinessAccount(AddBusinessAccountRequest request)
        {
            try
            {
                var response = new AddBusinessAccountResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var xlink = context.BusinessAccountCrossLinks.FirstOrDefault(ba => ba.AccountId.Equals(request.BusinessAccount.AccountId));
                    if (xlink != null)
                    {
                        if (xlink.BusinessId.Equals(request.BusinessAccount.BusinessId))
                            return new AddBusinessAccountResponse() { ErrorMessage = "This account is already attached to this business." };
                        return new AddBusinessAccountResponse() { ErrorMessage = "This account is already attached to another business." };
                    }

                    xlink = new BusinessAccountCrossLink
                    {
                        Id = Guid.NewGuid(),
                        BusinessId = request.BusinessAccount.BusinessId,
                        AccountId = request.BusinessAccount.AccountId,
                        IsOwner = request.BusinessAccount.IsOwner,
                        IsManager = request.BusinessAccount.IsManager,
                        DateCreated = DateTime.Now
                    };
                    context.BusinessAccountCrossLinks.Add(xlink);
                    context.SaveChanges();

                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new AddBusinessAccountResponse() { ErrorMessage = "Unable to add business account." };
            }
        }

        public RemoveBusinessAccountResponse RemoveBusinessAccount(RemoveBusinessAccountRequest request)
        {
            try
            {
                var response = new RemoveBusinessAccountResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var xlink = context.BusinessAccountCrossLinks.FirstOrDefault(ba => ba.AccountId.Equals(request.AccountId) && ba.BusinessId.Equals(request.BusinessId));
                    if (xlink == null) return new RemoveBusinessAccountResponse() { ErrorMessage = "This account is not attached to this business." };
                    context.BusinessAccountCrossLinks.Remove(xlink);
                    context.SaveChanges();
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new RemoveBusinessAccountResponse() { ErrorMessage = "Unable to remove business account." };
            }
        }



        private static string FormatAddress(string address1, string address2, string city, string state, string zipCode)
        {
            var formattedString = (string.IsNullOrEmpty(address1) ? "" : address1).Trim();
            formattedString += (string.IsNullOrEmpty(address2) ? "" : address2.Trim());
            var cityStateZip = FormatCityStateZip(city, state, zipCode);
            if (string.IsNullOrEmpty(cityStateZip))
                return formattedString.Trim();
            formattedString += (string.IsNullOrEmpty(formattedString) ? cityStateZip : ", " + cityStateZip).Trim();
            return formattedString.Trim();
        }

        private static string FormatCityStateZip(string city, string state, string zipCode)
        {
            var formattedString = (string.IsNullOrEmpty(city) ? "" : city).Trim();
            if (!string.IsNullOrEmpty(state))
                formattedString += (string.IsNullOrEmpty(formattedString) ? state : ", " + state).Trim();
            formattedString += string.IsNullOrEmpty(formattedString) ? zipCode : " " + zipCode;
            return formattedString.Trim();
        }
    }
}
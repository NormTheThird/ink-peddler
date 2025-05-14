using InkPeddler.Common.RequestAndResponses;
using System;
using System.Linq;
using InkPeddler.Common.Models;
using InkPeddler.Data;

namespace InkPeddler.Services
{
    public interface IDashboardService : IBaseService
    {
        GetDashboardTotalsResponse GetDashboardTotals(GetDashboardTotalsRequest request);
    }

    public class DashboardService : BaseService, IDashboardService
    {
        public GetDashboardTotalsResponse GetDashboardTotals(GetDashboardTotalsRequest request)
        {
            try
            {
                var response = new GetDashboardTotalsResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var totals = context.GetDashboardTotals().Select(t => new DashboardTotalsModel
                    {
                        ActiveUserCount = t.ActiveUserCount ?? 0,
                        InActiveUserCount = t.InActiveUserCount ?? 0,
                        ActiveArtistCount = t.ActiveArtistCount ?? 0,
                        InActiveArtistCount = t.InActiveArtistCount ?? 0,
                        ActiveBusinessCount = t.ActiveBusinessCount ?? 0,
                        InActiveBusinessCount = t.InActiveBusinessCount ?? 0,
                    }).FirstOrDefault();

                    totals.TattooCount = context.Tattoos.Count();
                    response.DashboardTotals = totals;
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new GetDashboardTotalsResponse { ErrorMessage = "Unable to get dashboard totals." };
            }
        }
    }
}

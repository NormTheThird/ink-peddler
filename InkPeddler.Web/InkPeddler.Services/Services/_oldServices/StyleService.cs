using InkPeddler.Common.Models;
using InkPeddler.Common.RequestAndResponses;
using InkPeddler.Data;
using System;
using System.Linq;

namespace InkPeddler.Services
{
    public interface IStyleService : IBaseService
    {
        GetStylesResponse GetStyles(GetStylesRequest request);
        GetStyleResponse GetStyle(GetStyleRequest request);
        SaveStyleResponse SaveStyle(SaveStyleRequest request);
        ChangeStyleStatusResponse ChangeStyleStatus(ChangeStyleStatusRequest request);
    }

    public class StyleService : BaseService, IStyleService
    {
        public GetStylesResponse GetStyles(GetStylesRequest request)
        {
            try
            {
                var response = new GetStylesResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var styles = context.Styles.AsNoTracking().Where(s => request.GetActiveAndInactive ? (s.IsActive || !s.IsActive) : s.IsActive)
                        .Select(s => new StyleModel
                        {
                            Id = s.Id,
                            Name = s.Name, 
                            Description = s.Description,
                            IsActive = s.IsActive, 
                            DateCreated = s.DateCreated
                        });
                    response.Styles = styles.ToList();
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new GetStylesResponse { ErrorMessage = "Unable to get styles." };
            }
        }

        public GetStyleResponse GetStyle(GetStyleRequest request)
        {
            try
            {
                var response = new GetStyleResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var style = context.Styles.AsNoTracking().FirstOrDefault(s => s.Id.Equals(request.StyleId));
                    if (style == null) throw new ApplicationException("Style does not exist for id " + request.StyleId);
                    response.Style = MapperService.Map<Style, StyleModel>(style);
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new GetStyleResponse { ErrorMessage = "Unable to get style." };
            }
        }

        public SaveStyleResponse SaveStyle(SaveStyleRequest request)
        {
            try
            {
                var now = DateTimeOffset.Now;
                var response = new SaveStyleResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var style = context.Styles.FirstOrDefault(a => a.Id.Equals(request.Style.Id));
                    if (style == null)
                    {
                        style = new Style {Id = Guid.NewGuid(), IsActive = true, DateCreated = now};
                        context.Styles.Add(style);
                    }

                    style.Name = request.Style.Name;
                    style.Description = request.Style.Description;
                    context.SaveChanges();
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new SaveStyleResponse() { ErrorMessage = "Unable to save style." };
            }
        }

        public ChangeStyleStatusResponse ChangeStyleStatus(ChangeStyleStatusRequest request)
        {
            try
            {
                var response = new ChangeStyleStatusResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var style = context.Styles.FirstOrDefault(a => a.Id.Equals(request.StyleId));
                    if (style == null) throw new ApplicationException("Style does not exist for id " + request.StyleId);
                    style.IsActive = !style.IsActive;
                    context.SaveChanges();
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new ChangeStyleStatusResponse { ErrorMessage = "Unable to change style status." };
            }
        }
    }
}
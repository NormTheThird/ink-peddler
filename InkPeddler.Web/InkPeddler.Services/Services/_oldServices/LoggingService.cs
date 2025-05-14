using System;
using System.Data.Entity.Validation;
using System.Linq;
using InkPeddler.Common.Extensions;
using InkPeddler.Common.Models;
using InkPeddler.Common.RequestAndResponses;
using InkPeddler.Data;

namespace InkPeddler.Services
{
    public interface ILoggingService
    {
        LogErrorResponse LogError(LogErrorRequest request);
        GetErrorsResponse GetErrors(GetErrorsRequest request);
        DeleteErrorResponse DeleteError(DeleteErrorRequest request);
        LogActivityResponse LogActivity(LogActivityRequest request);
    }

    public class LoggingService : ILoggingService
    {
        public LogErrorResponse LogError(LogErrorRequest request)
        {
            try
            {
                var entityError = "";
                var response = new LogErrorResponse();

                if (request.ex.GetType() == typeof(DbEntityValidationException))
                {
                    foreach (var entity in ((DbEntityValidationException)request.ex).EntityValidationErrors)
                    {
                        entityError += "[Entity: " + entity.Entry.Entity + " ";
                        entityError = entity.ValidationErrors.Aggregate(entityError,
                            (current, error) => current + ("[PropertyName: " + error.PropertyName + "][ErrorMessage: " + error.ErrorMessage + "]"));
                        entityError += "]";
                    }
                }

                using (var context = new InkPeddlerEntities())
                {
                    var error = new ErrorLog
                    {
                        Id = Guid.NewGuid(),
                        HResult = request.ex.HResult,
                        Source = request.ex.Source.Truncate(50),
                        ExceptionType = request.ex.GetType().Name.Truncate(50),
                        ExceptionMessage = (request.ex.Message + " " + entityError).Truncate(3000),
                        InnerExceptionMessage = request.ex.InnerException != null ? request.ex.InnerException.Message.Truncate(3000) : "",
                        StackTrace = request.ex.StackTrace.Truncate(3000),
                        Parameters = "",
                        IsReviewed = false,
                        ReviewedBy = "",
                        ReviewedComments = "",
                        DateReviwed = null,
                        DateCreated = DateTime.Now,
                    };

                    context.ErrorLogs.Add(error);
                    context.SaveChanges();

                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                return new LogErrorResponse { ErrorMessage = ex.Message };
            }
        }

        public GetErrorsResponse GetErrors(GetErrorsRequest request)
        {
            try
            {
                var response = new GetErrorsResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var errors = context.ErrorLogs.AsNoTracking()
                                        .Select(e => new ErrorLogModel
                                        {
                                            Id = e.Id,
                                            HResult = e.HResult,
                                            Source = e.Source,
                                            ExceptionType = e.ExceptionType,
                                            ExceptionMessage = e.ExceptionMessage,
                                            InnerExceptionMessage = e.InnerExceptionMessage,
                                            StackTrace = e.StackTrace,
                                            Parameters = e.Parameters,
                                            IsReviewed = e.IsReviewed,
                                            ReviewedBy = e.ReviewedBy,
                                            ReviewedComments = e.ReviewedComments,
                                            DateReviewed = e.DateReviwed,
                                            DateCreated = e.DateCreated
                                        }).OrderByDescending(e => e.DateCreated);
                    response.Errors = errors.ToList();
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LogError(new LogErrorRequest { ex = ex });
                return new GetErrorsResponse { ErrorMessage = "Unable to get errors." };
            }
        }

        public DeleteErrorResponse DeleteError(DeleteErrorRequest request)
        {
            try
            {
                var response = new DeleteErrorResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var error = context.ErrorLogs.FirstOrDefault(e => e.Id.Equals(request.ErrorId));
                    if (error == null) throw new ApplicationException($"Error does not exist for id {request.ErrorId}");
                    context.ErrorLogs.Remove(error);
                    context.SaveChanges();
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LogError(new LogErrorRequest { ex = ex });
                return new DeleteErrorResponse { ErrorMessage = "Unable to delete error." };
            }
        }

        public LogActivityResponse LogActivity(LogActivityRequest request)
        {
            try
            {
                var response = new LogActivityResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var activityLog = new ActivityLog()
                    {
                        Id = Guid.NewGuid(),
                        AccountId = request.AccountId,
                        ActivityType = request.ActivityType.ToString(),
                        DateCreated = DateTime.UtcNow,
                    };

                    context.ActivityLogs.Add(activityLog);
                    context.SaveChanges();

                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LogError(new LogErrorRequest { ex = ex });
                return new LogActivityResponse() { ErrorMessage = ex.Message };
            }
        }
    }
}
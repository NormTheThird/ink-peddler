using InkPeddler.Common.Models;
using InkPeddler.Common.RequestAndResponses;
using InkPeddler.Data;
using System;
using System.Linq;

namespace InkPeddler.Services
{
    public interface ITattooService : IBaseService
    {
        GetTattoosPerPageBySearchValueResponse GetTattoosPerPageBySearchValue(GetTattoosPerPageBySearchValueRequest request);
        GetTattoosPerPageWithMainImageResponse GetTattoosPerPageWithMainImage(GetTattoosPerPageWithMainImageRequest request);
        GetArtistTattoosWithMainImageResponse GetArtistTattoosWithMainImage(GetArtistTattoosWithMainImageRequest request);
        GetUserTattoosWithMainImageResponse GetUserTattoosWithMainImage(GetUserTattoosWithMainImageRequest request);
        GetAllTattoosResponse GetAllTattoos(GetAllTattoosRequest request);
        GetUploadedTattoosResponse GetUploadedTattoos(GetUploadedTattoosRequest request);
        GetTattooResponse GetTattoo(GetTattooRequest request);
        GetTattooImagesResponse GetTattooImages(GetTattooImagesRequest request);
        SaveTattooResponse SaveTattoo(SaveTattooRequest request);
        SaveTattooImageResponse SaveTattooImage(SaveTattooImageRequest request);
        SaveAsTattooMainImageResponse SaveAsTattooMainImage(SaveAsTattooMainImageRequest request);
        DeleteTattooImageResponse DeleteTattooImage(DeleteTattooImageRequest request);
        SaveTattooTatResponse SaveTattooTat(SaveTattooTatRequest request);
        GetTattooCommentsResponse GetTattooComments(GetTattooCommentsRequest request);
        GetTattooCommentResponse GetTattooComment(GetTattooCommentRequest request);
        SaveTattooCommentResponse SaveTattooComment(SaveTattooCommentRequest request);
        SaveTattooViewResponse SaveTattooView(SaveTattooViewRequest request);
        ChangeTattooStatusResponse ChangeTattooStatus(ChangeTattooStatusRequest request);
        ChangeTattooImageStatusResponse ChangeTattooImageStatus(ChangeTattooImageStatusRequest request);
        GetTattooTattedStatusResponse GetTattooTattedStatus(GetTattooTattedStatusRequest request);
    }

    public class TattooService : BaseService, ITattooService
    {
        public GetTattoosPerPageBySearchValueResponse GetTattoosPerPageBySearchValue(GetTattoosPerPageBySearchValueRequest request)
        {
            try
            {
                var response = new GetTattoosPerPageBySearchValueResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var tattoos = context.GetTattoosPerPageBySearchValue(request.PageNumber, request.SearchValue)
                        .Select(t => new TattooWithMainImageModel
                        {
                            Id = t.Id,
                            UploadedByAccountId = t.UploadedByAccountId,
                            AWSImageId = t.AWSImageId,
                            CanvasAccountId = t.CanvasAccountId,
                            ArtistAccountId = t.ArtistAccountId,
                            BusinessId = t.BusinessId,
                            Name = t.Name,
                            Description = t.Description,
                            IsActive = t.IsActive,
                            DateCreated = t.DateCreated
                        });
                    response.Tattoos = tattoos.ToList();
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new GetTattoosPerPageBySearchValueResponse { ErrorMessage = "Unable to get tattoos per page by search value." };
            }
        }

        public GetTattoosPerPageWithMainImageResponse GetTattoosPerPageWithMainImage(GetTattoosPerPageWithMainImageRequest request)
        {
            try
            {
                var response = new GetTattoosPerPageWithMainImageResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var tattoos = context.GetTattoosPerPageWithMainImage(request.PageNumber, request.StyleId)
                        .Select(t => new TattooWithMainImageModel
                        {
                            Id = t.Id,
                            UploadedByAccountId = t.UploadedByAccountId,
                            AWSImageId = t.AWSImageId,
                            CanvasAccountId = t.CanvasAccountId,
                            ArtistAccountId = t.ArtistAccountId,
                            BusinessId = t.BusinessId,
                            Name = t.Name,
                            Description = t.Description,
                            IsActive = t.IsActive,
                            DateCreated = t.DateCreated

                        });
                    response.Tattoos = tattoos.ToList();
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new GetTattoosPerPageWithMainImageResponse { ErrorMessage = "Unable to get tattoos per page with main image." };
            }
        }

        public GetArtistTattoosWithMainImageResponse GetArtistTattoosWithMainImage(GetArtistTattoosWithMainImageRequest request)
        {
            try
            {
                var response = new GetArtistTattoosWithMainImageResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var tattoos = context.GetArtistTattoosWithMainImage(request.ArtistAccountId)
                        .Select(t => new TattooWithMainImageModel
                        {
                            Id = t.Id,
                            UploadedByAccountId = t.UploadedByAccountId,
                            AWSImageId = t.AWSImageId,
                            CanvasAccountId = t.CanvasAccountId,
                            ArtistAccountId = t.ArtistAccountId,
                            BusinessId = t.BusinessId,
                            Name = t.Name,
                            Description = t.Description,
                            IsActive = t.IsActive,
                            DateCreated = t.DateCreated
                        });
                    response.Tattoos = tattoos.ToList();
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new GetArtistTattoosWithMainImageResponse { ErrorMessage = "Unable to get artist tattoos with main image." };
            }
        }

        public GetUserTattoosWithMainImageResponse GetUserTattoosWithMainImage(GetUserTattoosWithMainImageRequest request)
        {
            try
            {
                var response = new GetUserTattoosWithMainImageResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var tattoos = context.GetUserTattoosWithMainImage(request.UploadedByAccountId)
                        .Select(t => new TattooWithMainImageModel
                        {
                            Id = t.Id,
                            UploadedByAccountId = t.UploadedByAccountId,
                            AWSImageId = t.AWSImageId,
                            CanvasAccountId = t.CanvasAccountId,
                            ArtistAccountId = t.ArtistAccountId,
                            BusinessId = t.BusinessId,
                            Name = t.Name,
                            Description = t.Description,
                            IsActive = t.IsActive,
                            DateCreated = t.DateCreated

                        });
                    response.Tattoos = tattoos.ToList();
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new GetUserTattoosWithMainImageResponse { ErrorMessage = "Unable to get user tattoos with main image." };
            }
        }

        public GetAllTattoosResponse GetAllTattoos(GetAllTattoosRequest request)
        {
            try
            {
                var response = new GetAllTattoosResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var tattoos = context.Tattoos.AsNoTracking()
                        .Select(t => new TattooQuickModel
                        {
                            Id = t.Id,
                            Name = t.Name,
                            NumberOfComments = t.TattooComments.Count(),
                            NumberOfTats = t.TattooTats.Count(),
                            NumberOfViews = t.TattooViews.Count(),
                            IsActive = t.IsActive,
                            DateCreated = t.DateCreated
                        });
                    response.Tattoos = tattoos.ToList();
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new GetAllTattoosResponse { ErrorMessage = "Unable to get all tattoos." };
            }
        }

        public GetUploadedTattoosResponse GetUploadedTattoos(GetUploadedTattoosRequest request)
        {
            try
            {
                var response = new GetUploadedTattoosResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var tattoos = context.Tattoos.AsNoTracking()
                                         .Where(t => t.UploadedByAccountId.Equals(request.UploadedAccountId) && t.IsActive)
                                         .Select(t => new TattooQuickModel
                                         {
                                             Id = t.Id,
                                             Name = t.Name,
                                             NumberOfComments = t.TattooComments.Count(),
                                             NumberOfTats = t.TattooTats.Count(),
                                             NumberOfViews = t.TattooViews.Count(),
                                             IsActive = t.IsActive,
                                             DateCreated = t.DateCreated
                                         });
                    response.Tattoos = tattoos.ToList();
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new GetUploadedTattoosResponse { ErrorMessage = "Unable to get uploaded tattoos." };
            }
        }

        public GetTattooResponse GetTattoo(GetTattooRequest request)
        {
            try
            {
                var response = new GetTattooResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var tattoo = context.Tattoos.AsNoTracking().FirstOrDefault(t => t.Id == request.TattooId);
                    if (tattoo == null) throw new ApplicationException($"Unable to get tattoo for id {request.TattooId}");
                    response.Tattoo = MapperService.Map<Tattoo, TattooModel>(tattoo);
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new GetTattooResponse { ErrorMessage = "Unable to get tattoo." };
            }
        }

        public GetTattooImagesResponse GetTattooImages(GetTattooImagesRequest request)
        {
            try
            {
                var response = new GetTattooImagesResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var tattooImages = context.TattooImages.AsNoTracking()
                        .Where(ti => ti.TattooId == request.TattooId)
                        .Select(ti => new TattooImageModel
                        {
                            Id = ti.Id,
                            TattooId = ti.TattooId,
                            AWSImageId = ti.AWSImageId,
                            IsActive = ti.IsActive,
                            IsMainImage = ti.IsMainImage,
                            DateCreated = ti.DateCreated
                        });
                    response.TattooImages = tattooImages.ToList();
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new GetTattooImagesResponse { ErrorMessage = "Unable to get tattoo images." };
            }
        }

        public SaveTattooResponse SaveTattoo(SaveTattooRequest request)
        {
            try
            {
                var now = DateTimeOffset.Now;
                var response = new SaveTattooResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var tattoo = context.Tattoos.FirstOrDefault(a => a.Id.Equals(request.Tattoo.Id));
                    if (tattoo == null)
                    {
                        tattoo = new Tattoo { Id = Guid.NewGuid(), UploadedByAccountId = request.Tattoo.UploadedByAccountId, IsActive = true, DateCreated = now };
                        context.Tattoos.Add(tattoo);
                    }

                    MapperService.Map(request.Tattoo, tattoo);
                    if (tattoo.CanvasAccountId.Equals(Guid.Empty)) tattoo.CanvasAccountId = null;
                    if (tattoo.ArtistAccountId.Equals(Guid.Empty)) tattoo.ArtistAccountId = null;
                    if (tattoo.BusinessId.Equals(Guid.Empty)) tattoo.BusinessId = null;
                    context.SaveChanges();

                    response.TattooId = tattoo.Id;
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new SaveTattooResponse { ErrorMessage = "Unable to save tattoo." };
            }
        }

        public SaveTattooImageResponse SaveTattooImage(SaveTattooImageRequest request)
        {
            try
            {
                var now = DateTimeOffset.Now;
                var response = new SaveTattooImageResponse();
                using (var context = new InkPeddlerEntities())
                {
                    //TODO: TREY: 12/22/2018 Not sure if this is the best way but for now this should work. This removes the main image flag from the
                    //current main image and sets it to the new image being saved.
                    var currentTattoos = context.TattooImages.Where(ti => ti.TattooId.Equals(request.TattooImage.TattooId) && ti.IsMainImage);
                    foreach (var currentTattoo in currentTattoos)
                        currentTattoo.IsMainImage = false;                        

                    var tattooImage = new TattooImage
                    {
                        Id = Guid.NewGuid(),
                        TattooId = request.TattooImage.TattooId,
                        AWSImageId = request.TattooImage.AWSImageId,
                        IsActive = true,
                        IsMainImage = true,
                        DateCreated = now
                    };
                    context.TattooImages.Add(tattooImage);
                    context.SaveChanges();

                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new SaveTattooImageResponse { ErrorMessage = "Unable to save tattoo image." };
            }
        }

        public SaveAsTattooMainImageResponse SaveAsTattooMainImage(SaveAsTattooMainImageRequest request)
        {
            try
            {
                var now = DateTimeOffset.Now;
                var response = new SaveAsTattooMainImageResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var image = context.TattooImages.FirstOrDefault(ti => ti.Id.Equals(request.TattooImageId));
                    if (image == null) throw new ApplicationException($"Tattoo image does not exist for id {request.TattooImageId}");
                    var images = context.TattooImages.Where(ti => ti.TattooId.Equals(image.TattooId) && ti.IsMainImage);
                    foreach (var mainImage in images)
                        mainImage.IsMainImage = false;

                    image.IsMainImage = true;
                    context.SaveChanges();
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new SaveAsTattooMainImageResponse { ErrorMessage = "Unable to save as tattoo main image." };
            }
        }

        public DeleteTattooImageResponse DeleteTattooImage(DeleteTattooImageRequest request)
        {
            try
            {
                var now = DateTimeOffset.Now;
                var response = new DeleteTattooImageResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var image = context.TattooImages.FirstOrDefault(ti => ti.Id.Equals(request.TattooImageId));
                    if (image == null) throw new ApplicationException($"Tattoo image does not exist for id {request.TattooImageId}");
                    context.TattooImages.Remove(image);
                    if(image.IsMainImage)
                    {
                        var newMainImage = context.TattooImages.FirstOrDefault(ti => ti.TattooId.Equals(image.TattooId) && !ti.IsMainImage);
                        if (newMainImage != null)
                            newMainImage.IsMainImage = true;
                    }

                    context.SaveChanges();
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new DeleteTattooImageResponse { ErrorMessage = "Unable to delete tattoo image." };
            }
        }

        public SaveTattooTatResponse SaveTattooTat(SaveTattooTatRequest request)
        {
            try
            {
                var now = DateTimeOffset.Now;
                var response = new SaveTattooTatResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var tattooTat = context.TattooTats.FirstOrDefault(tt => tt.AccountId.Equals(request.AccountId) && tt.TattooId.Equals(request.TattooId));
                    if (tattooTat == null)
                    {
                        tattooTat = new TattooTat { Id = Guid.NewGuid(), TattooId = request.TattooId, AccountId = request.AccountId, DateCreated = now };
                        context.TattooTats.Add(tattooTat);
                        context.SaveChanges();
                    }

                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new SaveTattooTatResponse { ErrorMessage = "Unable to save tattoo tat." };
            }
        }

        public GetTattooCommentsResponse GetTattooComments(GetTattooCommentsRequest request)
        {
            try
            {
                var response = new GetTattooCommentsResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var tattooComments = context.TattooComments.AsNoTracking().Where(t =>
                            t.TattooId.Equals(request.TattooId) && (request.GetActiveAndInactive
                                ? (t.IsActive || !t.IsActive)
                                : (t.IsActive)))
                        .Select(tc => new TattooCommentModel
                        {
                            Id = tc.Id,
                            TattooId = tc.TattooId,
                            AccountId = tc.AccountId,
                            Comment = tc.Comment,
                            IsActive = tc.IsActive,
                            DateCreated = tc.DateCreated
                        });
                    if (tattooComments.Any())
                        response.TattooComments = tattooComments.ToList();
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new GetTattooCommentsResponse { ErrorMessage = "Unable to get tattoo comments." };
            }
        }

        public GetTattooCommentResponse GetTattooComment(GetTattooCommentRequest request)
        {
            try
            {
                var response = new GetTattooCommentResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var tattooComment = context.TattooComments.AsNoTracking().FirstOrDefault(t => t.Id.Equals(request.TattooCommentId));
                    response.TattooComment = MapperService.Map<TattooComment, TattooCommentModel>(tattooComment);
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new GetTattooCommentResponse { ErrorMessage = "Unable to get tattoo comment." };
            }
        }

        public SaveTattooCommentResponse SaveTattooComment(SaveTattooCommentRequest request)
        {
            try
            {
                var now = DateTimeOffset.Now;
                var response = new SaveTattooCommentResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var tattooComment = context.TattooComments.FirstOrDefault(a => a.Id.Equals(request.TattooComment.Id));
                    if (tattooComment == null)
                    {
                        tattooComment = new TattooComment { Id = Guid.NewGuid(), TattooId = request.TattooComment.TattooId, AccountId = request.TattooComment.AccountId, DateCreated = now };
                        context.TattooComments.Add(tattooComment);
                    }

                    MapperService.Map(request.TattooComment, tattooComment);
                    context.SaveChanges();

                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new SaveTattooCommentResponse { ErrorMessage = "Unable to save tattoo comment." };
            }
        }

        public SaveTattooViewResponse SaveTattooView(SaveTattooViewRequest request)
        {
            try
            {
                var now = DateTime.UtcNow;
                var response = new SaveTattooViewResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var view = new TattooView
                    {
                        Id = Guid.NewGuid(),
                        TattooId = request.TattooId,
                        AccountId = request.AccountId,
                        DateCreated = now,
                    };
                    context.TattooViews.Add(view);
                    context.SaveChanges();

                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new SaveTattooViewResponse { ErrorMessage = "Unable to save tattoo view" };
            }
        }

        public ChangeTattooStatusResponse ChangeTattooStatus(ChangeTattooStatusRequest request)
        {
            try
            {
                var response = new ChangeTattooStatusResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var tattoo = context.Tattoos.FirstOrDefault(a => a.Id.Equals(request.TattooId));
                    if (tattoo == null) throw new ApplicationException("Tattoo does not exist for id " + request.TattooId);
                    tattoo.IsActive = !tattoo.IsActive;
                    context.SaveChanges();
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new ChangeTattooStatusResponse { ErrorMessage = "Unable to change tattoo status." };
            }
        }

        public ChangeTattooImageStatusResponse ChangeTattooImageStatus(ChangeTattooImageStatusRequest request)
        {
            try
            {
                var response = new ChangeTattooImageStatusResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var image = context.TattooImages.FirstOrDefault(ti => ti.Id.Equals(request.TattooImageId));
                    if (image == null) throw new ApplicationException($"Tattoo image does not exist for id {request.TattooImageId}");
                    image.IsActive = !image.IsActive;

                    if (image.IsMainImage)
                    {
                        var newMainImage = context.TattooImages.FirstOrDefault(ti => ti.TattooId.Equals(image.TattooId) && !ti.IsMainImage);
                        if (newMainImage != null)
                            newMainImage.IsMainImage = true;
                    }

                    context.SaveChanges();
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new ChangeTattooImageStatusResponse { ErrorMessage = "Unable to change tattoo image status." };
            }
        }

        public GetTattooTattedStatusResponse GetTattooTattedStatus(GetTattooTattedStatusRequest request)
        {
            try
            {
                var response = new GetTattooTattedStatusResponse();
                using (var context = new InkPeddlerEntities())
                {
                    var tat = context.TattooTats.AsNoTracking().FirstOrDefault(a => a.TattooId.Equals(request.TattooId) && a.AccountId.Equals(request.AccountId));
                    response.IsTatted = tat != null;
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogError(new LogErrorRequest { ex = ex });
                return new GetTattooTattedStatusResponse { ErrorMessage = "Unable to get tattoo tatted status" };
            }
        }
    }
}
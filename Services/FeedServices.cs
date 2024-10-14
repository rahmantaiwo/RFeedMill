using Azure.Core;
using QFeedMill.Models.Dto;
using QFeedMill.Models.Dto.Feed;
using QFeedMill.Models.Entities;
using QFeedMill.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QFeedMill.Services
{
    public class FeedServices : IFeedServices
    {
        private readonly IFeedRepository _feedRepository;
        private readonly ApplicationDbContext _dbContext;
        public FeedServices(IFeedRepository feedRepository, ApplicationDbContext dbContext)
        {
            _feedRepository = feedRepository;
            _dbContext = dbContext;
        }

        public async Task<BaseResponse<bool>> CreateFeed(CreateFeedDto request)
        {
            try
            {
               
                var newFeed = new Feed()
                {
                    Phase = request.Phase,
                    FeedCategoryId = request.FeedCategoryId,
                    Kilogram = request.Kilogram,
                    Quantity = request.Quantity,
                    Price = request.Price
                };
                await _dbContext.Feeds.AddAsync(newFeed);
                if (await _dbContext.SaveChangesAsync() > 0)
                {
                    return new BaseResponse<bool> { Message = "Feed created succesful", IsSuccessful = true, Data = true };
                }
                return new BaseResponse<bool> { Message = "Feed Creation failed", IsSuccessful = false, Data = false };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool> { Message = $"Error :  {ex.Message}", IsSuccessful = false, Data = false };
            }
        }

        public async Task<BaseResponse<bool>> DeleteFeed(Guid id)
        {
            try
            {
                var feed = await _feedRepository.GetFeedAsync(id);
                if (feed != null)
                {
                    _dbContext.Feeds.Remove(feed);

                    if (await _dbContext.SaveChangesAsync() > 0)
                    {
                        return new BaseResponse<bool> { Message = "Feed deleted successfully", IsSuccessful = true, Data = true };
                    }
                }
                return new BaseResponse<bool> { Message = "Feed not found", IsSuccessful = false, Data = false };
            }
			catch (Exception ex)
			{

				return new BaseResponse<bool> { Message = $"Error :  {ex.Message}", IsSuccessful = false, Data = false };
			}
		}


        public async Task<BaseResponse<List<FeedDto>>> GetAllFeeds()
        {
            try
            {
                var feed = await _feedRepository.GetAllFeedAsync();
                if (feed.Count > 0)
                {
                    var data = feed.Select(x => new FeedDto
                    {
                        Id = x.Id,
                        Phase = x.Phase,
                        FeedCategoryId = x.FeedCategoryId,
                        Kilogram = x.Kilogram,
                        Quantity = x.Quantity,  
                        Price = x.Price
                    }).ToList();
                    return new BaseResponse<List<FeedDto>> { Message = "Data retrieved successfully", IsSuccessful = false, Data = data };
                }
                return new BaseResponse<List<FeedDto>> { Message = "No record", IsSuccessful = false, Data = new List<FeedDto>() };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<FeedDto>> { Message = $"Error : {ex.Message}", IsSuccessful = false, Data = new List<FeedDto>() };
            }
        }


        public async Task<BaseResponse<FeedDto>> GetFeed(Guid id)
        {
            try
            {
                var feed = await _feedRepository.GetFeedAsync(id);
                if (feed != null)
                {
                    var data = new FeedDto
                    {
                        Phase = feed.Phase,
                        FeedCategoryId = feed.FeedCategoryId,
                        Kilogram = feed.Kilogram,
                        Quantity = feed.Quantity,
                        Price = feed.Price
                    };
                    return new BaseResponse<FeedDto> { Message = "Data retrieved succesful", IsSuccessful = false, Data = data };
                }
                return new BaseResponse<FeedDto> { Message = "No record", IsSuccessful = false, Data = new FeedDto() };
            }
            catch (Exception ex)
            {
                return new BaseResponse<FeedDto> { Message = $"Error : {ex.Message}", IsSuccessful = false, Data = new FeedDto() };
            }
        }

        public async Task<BaseResponse<bool>> UpdateFeed(Guid id, UpdateFeedDto request)
        {
            try
            {
                var feed = await _feedRepository.GetFeedAsync(id);
            if (feed != null)
                {
                    feed.Phase = request.Phase;
                    feed.FeedCategoryId = request.FeedCategoryId;
                    feed.Kilogram = request.Kilogram;
                    feed.Quantity = request.Quantity;
                    feed.Price = request.Price;

                    _dbContext.Feeds.Update(feed);
                    if (await _dbContext.SaveChangesAsync() > 0)
                {
                        return new BaseResponse<bool> { Message = "Book updated successfully", IsSuccessful = true, Data = true };
                    }
                }
                return new BaseResponse<bool> { Message = "Book not found", IsSuccessful = false, Data = false };
            }
            catch (Exception ex)
            {

                return new BaseResponse<bool> { Message = $"Error :  {ex.Message}", IsSuccessful = false, Data = false };
            }
        }
    }
}
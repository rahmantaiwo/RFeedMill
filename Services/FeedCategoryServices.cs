using QFeedMill.Models.Category;
using QFeedMill.Models.Dto;
using QFeedMill.Models.Dto.Feed;
using QFeedMill.Models.Dto.FeedCategory;
using QFeedMill.Repository;

namespace QFeedMill.Services
{
    public class FeedCategoryServices : IFeedCategoryServices
    {
        private readonly IFeedCategoryRepository _feedCategoryRepository;
        private readonly ApplicationDbContext _dbContext;
        public FeedCategoryServices(IFeedCategoryRepository feedCategoryRepository, ApplicationDbContext dbContext)
        {
            _feedCategoryRepository = feedCategoryRepository;
            _dbContext = dbContext;
        }

        public async Task<BaseResponse<bool>> CreateFeedCategory(CreateFeedCategoryDto request)
        {
            try
            {
                var newFeedCategory = new FeedCategory()
                {
                    Name = request.Name,
                };
                await _dbContext.FeedCategories.AddAsync(newFeedCategory);
                if (await _dbContext.SaveChangesAsync() > 0)
                {
                    return new BaseResponse<bool> { Message = "FeedCategory created successful", IsSuccessful = true, Data = true };
                }
                return new BaseResponse<bool> { Message = "FeedCategory created failed", IsSuccessful = false, Data = false };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool> { Message = $"Error :  {ex.Message}", IsSuccessful = false, Data = false };
            }
        }

        public async Task<BaseResponse<bool>> DeleteFeedCategory(Guid id)
        {
            try
            {
                var feedCategory = await _feedCategoryRepository.GetFeedCategoryAsync(id);
                if (feedCategory == null)
                {

                    return new BaseResponse<bool> { Message = "Not found", IsSuccessful = false, Data = true };
                }

                _dbContext.FeedCategories.Remove(feedCategory);


                if (await _dbContext.SaveChangesAsync() > 0)
                {
                    return new BaseResponse<bool> { Message = "FeedCategory deleted successful", IsSuccessful = true, Data = true };
                }

                return new BaseResponse<bool> { Message = "FeedCategory delete failed", IsSuccessful = false, Data = false };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool> { Message = $"Error : {ex.Message}", IsSuccessful = false, Data = false };
            }
        }

        public async Task<BaseResponse<List<FeedCategoryDto>>> GetAllFeedCategories()
        {
            try
            {
                var feedCategory = await _feedCategoryRepository.GetFeddCategoriesAsync();
                if (feedCategory == null || feedCategory.Count == 0)
                {

                    return new BaseResponse<List<FeedCategoryDto>> { Message = "No record", IsSuccessful = false, Data = new List<FeedCategoryDto>() };
                }

                var data = feedCategory.Select(x => new FeedCategoryDto
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToList();

                return new BaseResponse<List<FeedCategoryDto>> { Message = "Data retrieved successfully", IsSuccessful = false, Data = data };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<FeedCategoryDto>> { Message = $"Error : {ex.Message}", IsSuccessful = false, Data = new List<FeedCategoryDto>() };
            }
        }

        public async Task<BaseResponse<FeedCategoryDto>> GetFeedCategory(Guid id)
        {
            try
            {
                var feedCategory = await _feedCategoryRepository.GetFeedCategoryAsync(id);
                if (feedCategory != null)
                {
                    var data = new FeedCategoryDto
                    {
                        Id = id,
                        Name = feedCategory.Name
                    };
                    return new BaseResponse<FeedCategoryDto> { Message = "Data retrieved succesful", IsSuccessful = false, Data = data };
                }
                return new BaseResponse<FeedCategoryDto> { Message = "No record", IsSuccessful = false, Data = new FeedCategoryDto() };
            }
            catch (Exception ex)
            {
                return new BaseResponse<FeedCategoryDto> { Message = $"Error : {ex.Message}", IsSuccessful = false, Data = new FeedCategoryDto() };
            }

        }


        public async Task<BaseResponse<bool>> CheckIfFeedCategoryExist(Guid id)
        {
            try
            {
                var feedCategory = await _feedCategoryRepository.GetFeedCategoryAsync(id);
                if (feedCategory != null)
                {

                    return new BaseResponse<bool> { Message = "Data retrieved succesful", IsSuccessful = false, Data = true };
                }
                return new BaseResponse<bool> { Message = "No record", IsSuccessful = false, Data = false };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool> { Message = $"Error : {ex.Message}", IsSuccessful = false, Data = false };
            }

        }

        public async Task<BaseResponse<bool>> UpdateFeedCategory(Guid id, UpdateFeedCategoryDto request)
        {
            try
            {
                var feedCategory = await _feedCategoryRepository.GetFeedCategoryAsync(id);


                if (feedCategory == null)
                {

                    return new BaseResponse<bool> { Message = "No record", IsSuccessful = false, Data = false };
                }

                feedCategory.Name = request.Name;
                feedCategory.UpdateDate = DateTime.Now;


                _dbContext.FeedCategories.Update(feedCategory);


                if (await _dbContext.SaveChangesAsync() > 0)
                {
                    return new BaseResponse<bool> { Message = "FeedCategory Updated successful", IsSuccessful = true, Data = true };
                }

                return new BaseResponse<bool> { Message = "FeedCategory Update failed", IsSuccessful = false, Data = false };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool> { Message = $"Error :  {ex.Message}", IsSuccessful = false, Data = false };
            }

        }
    }
}





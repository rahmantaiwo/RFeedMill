using QFeedMill.Models.Dto;
using QFeedMill.Models.Dto.FeedCategory;

namespace QFeedMill.Services
{
    public interface IFeedCategoryServices
    {
        Task<BaseResponse<bool>> CheckIfFeedCategoryExist(Guid id);
        Task<BaseResponse<bool>> CreateFeedCategory(CreateFeedCategoryDto request);
        Task<BaseResponse<bool>> DeleteFeedCategory(Guid id);
        Task<BaseResponse<List<FeedCategoryDto>>> GetAllFeedCategories();
        Task<BaseResponse<FeedCategoryDto>> GetFeedCategory(Guid id);
        Task<BaseResponse<bool>> UpdateFeedCategory(Guid id, UpdateFeedCategoryDto request);
    }
}
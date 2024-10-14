using QFeedMill.Models.Dto;
using QFeedMill.Models.Dto.FeedCategory;

namespace QFeedMill.Models.IServices
{
    public interface IFeedCategoryServices
    {
        Task<BaseResponse<bool>> CreateFeedCategory(CreateFeedCategoryDto request);
        Task<BaseResponse<bool>> UpdateFeedCategory(Guid id, UpdateFeedCategoryDto request);
        Task<BaseResponse<bool>> GetFeedCategory(Guid id);
        Task<BaseResponse<List<FeedCategoryDto>>> GetAllFeedCategories();
        Task<BaseResponse<bool>> DeleteFeedCategory(Guid id);
    }
}

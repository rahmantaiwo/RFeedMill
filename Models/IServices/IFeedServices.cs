using QFeedMill.Models.Dto;
using QFeedMill.Models.Dto.Feed;

namespace QFeedMill.Models.IServices
{
    public interface IFeedServices
    {
        Task<BaseResponse<bool>> CreateFeed(CreateFeedDto request);
        Task<BaseResponse<bool>> UpdateFeed(Guid id, UpdateFeedDto request);
        Task<BaseResponse<FeedDto>> GetFeed(Guid id);
        Task<BaseResponse<bool>> DeleteFeed(Guid id);
        Task<BaseResponse<List<FeedDto>>> GetAllFeeds();
    }
}

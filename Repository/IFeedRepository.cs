using QFeedMill.Models.Entities;
using QFeedMill.Models.Enum;

namespace QFeedMill.Repository
{
    public interface IFeedRepository
    {
        Task<List<Feed>> GetAllFeedAsync();
        Task<Feed?> GetFeedAsync(Guid id);
        Task<Feed?> GetFeedByPhaseAsync(FeedPhases phase);
    }
}
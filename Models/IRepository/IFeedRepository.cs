using QFeedMill.Models.Entities;
using QFeedMill.Models.Enum;

namespace QFeedMill.Models.IRepository
{
    public interface IFeedRepository
    {
        Task<Feed> GetFeedAsync(Guid id);
        Task<List<Feed>> GetAllFeedAsync();
        Task<Feed?> GetFeedByPhaseAsync(FeedPhases phase);
    }
}

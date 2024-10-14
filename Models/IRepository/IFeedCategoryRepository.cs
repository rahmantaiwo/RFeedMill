using QFeedMill.Models.Category;

namespace QFeedMill.Models.IRepository
{
    public interface IFeedCategoryRepository
    {
        Task<List<FeedCategory>> GetFeedCategoryAsync(Guid id);
        Task<FeedCategory> GetAllFeedCategoryAsync();
    }
}

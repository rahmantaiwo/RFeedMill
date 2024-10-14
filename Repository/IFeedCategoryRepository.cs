using QFeedMill.Models.Category;

namespace QFeedMill.Repository
{
    public interface IFeedCategoryRepository
    {
        Task<List<FeedCategory>> GetFeddCategoriesAsync();
        Task<FeedCategory?> GetFeedCategoryAsync(Guid id);
        Task<FeedCategory?> GetFeedCategoryByNameAsync(string name);
    }
}
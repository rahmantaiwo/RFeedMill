using QFeedMill.Models.Entities;

namespace QFeedMill.Repository
{
	public interface IFeedCategoryRepository
    {
        Task<List<FeedCategory>> GetFeedCategoriesAsync();
        Task<FeedCategory?> GetFeedCategoryAsync(Guid id);
        Task<FeedCategory?> GetFeedCategoryByNameAsync(string name);
    }
}
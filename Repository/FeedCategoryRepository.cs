
using Microsoft.EntityFrameworkCore;
using QFeedMill.Models.Category;

namespace QFeedMill.Repository
{
    public class FeedCategoryRepository : IFeedCategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public FeedCategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<FeedCategory>> GetFeddCategoriesAsync()
        {
            return await _dbContext.FeedCategories.ToListAsync();
        }

        public async Task<FeedCategory?> GetFeedCategoryAsync(Guid id)
        {
            return await _dbContext.FeedCategories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<FeedCategory?> GetFeedCategoryByNameAsync(string name)
        {
            return await _dbContext.FeedCategories.FirstOrDefaultAsync(x => x.Name == name);
        }


    }
}

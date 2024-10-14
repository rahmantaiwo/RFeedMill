
using Microsoft.EntityFrameworkCore;
using QFeedMill.Models.Category;
using QFeedMill.Models.IRepository;

namespace QFeedMill.Repository
{
    public class FeedCategoryRepository : IFeedCategoryRepository
	{
		private readonly ApplicationDbContext _dbContext;
		public FeedCategoryRepository(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task<List<FeedCategory>> GetAllFeedCategoryAsync()
		{
			return await _dbContext.FeedCategories.ToListAsync();
		}

		public Task<List<FeedCategory>> GetFeedCategoryAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		public async Task<FeedCategory?> GetFeedCategoryByIdAsync(Guid id)
		{
			return await _dbContext.FeedCategories.FirstOrDefaultAsync(x => x.Id == id);
		}

		Task<FeedCategory> IFeedCategoryRepository.GetAllFeedCategoryAsync()
		{
			throw new NotImplementedException();
		}
	}
}

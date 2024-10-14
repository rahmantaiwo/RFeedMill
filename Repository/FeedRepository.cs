using Microsoft.EntityFrameworkCore;
using QFeedMill.Models.Entities;
using QFeedMill.Models.Enum;

namespace QFeedMill.Repository
{
    public class FeedRepository : IFeedRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public FeedRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Feed>> GetAllFeedAsync()
        {
            return await _dbContext.Feeds.ToListAsync();
        }

        public async Task<Feed?> GetFeedByPhaseAsync(FeedPhases phase)
        {
            return await _dbContext.Feeds.Where(x => x.Phase == phase).FirstOrDefaultAsync();
        }

        public async Task<Feed?> GetFeedAsync(Guid id)
        {
            return await _dbContext.Feeds.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}

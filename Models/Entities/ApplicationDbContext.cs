using Microsoft.EntityFrameworkCore;

namespace QFeedMill.Models.Entities
{
    public class ApplicationDbContext : DbContext
    {
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Feed> Feeds { get; set; }
        public DbSet<FeedCategory> FeedCategories { get; set; }
        
    }
}

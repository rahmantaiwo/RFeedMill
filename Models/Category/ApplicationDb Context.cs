using Microsoft.EntityFrameworkCore;

namespace QFeedMill.Models.Category
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{
		}
		public DbSet<FeedCategory> FeedCategories { get; set; }
	}
}

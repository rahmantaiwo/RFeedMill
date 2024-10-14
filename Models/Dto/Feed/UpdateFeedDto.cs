using Microsoft.AspNetCore.Mvc;
using QFeedMill.Models.Entities;
using QFeedMill.Models.Enum;

namespace QFeedMill.Models.Dto.Feed
{
    public class UpdateFeedDto 
	{
		public FeedPhases Phase { get; set; }
		public Guid FeedCategoryId { get; set; }
		public float Kilogram { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }
	}
}

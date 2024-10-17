using Microsoft.AspNetCore.Mvc;
using QFeedMill.Models.Entities;
using QFeedMill.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace QFeedMill.Models.Dto.Feed
{
    public class CreateFeedDto
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		[Required(ErrorMessage = "Phase is required")]
		public FeedPhases Phase { get; set; }
		//[Required(ErrorMessage = "FeedCategory is required")]
		//public string Name { get; set; }
		[Required(ErrorMessage = "Kilogram is required")]
		public float Kilogram { get; set; }
		[Required(ErrorMessage = "Quantity is required")]
		public int Quantity { get; set; }
		[Required(ErrorMessage = "Price is required")]
		public decimal Price { get; set; }
		public Guid FeedCategoryId { get; set; }
		public DateTime CreateDate { get; set; } = DateTime.Now;
		public DateTime? UpdatedDate { get; set; }
	}
}

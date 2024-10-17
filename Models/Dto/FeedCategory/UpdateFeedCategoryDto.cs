using System.ComponentModel.DataAnnotations;

namespace QFeedMill.Models.Dto.FeedCategory
{
	public class UpdateFeedCategoryDto
	{
		[Required(ErrorMessage = "Name is required")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Name is required")]
		public Guid Id { get; set; } = Guid.NewGuid();
		public DateTime? UpdatedDate { get; set; }

	}
}

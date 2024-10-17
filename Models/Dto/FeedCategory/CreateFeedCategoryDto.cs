using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace QFeedMill.Models.Dto.FeedCategory
{
	public class CreateFeedCategoryDto 
	{
		[Required(ErrorMessage = "Name is required")]
		public string Name { get; set; }

	}
}

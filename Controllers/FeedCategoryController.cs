using Microsoft.AspNetCore.Mvc;
using QFeedMill.Models.Dto.Feed;
using QFeedMill.Models.Dto.FeedCategory;
using QFeedMill.Models.Entities;
using QFeedMill.Services;

namespace QFeedMill.Controllers
{
	public class FeedCategoryController : Controller
	{
		private readonly IFeedCategoryServices _feedCategoryServices;
        public FeedCategoryController(IFeedCategoryServices feedCategoryServices)
		{
			_feedCategoryServices = feedCategoryServices;
		}

		[HttpGet("all-feedCategories")]
		public async Task<IActionResult> FeedCategories()
		{
			var result = await _feedCategoryServices.GetAllFeedCategories();
			return View(result.Data);
		}

		[HttpGet("feedcategory/{id}")]
		public async Task<IActionResult> FeedCategoryDetailAsync([FromRoute] Guid id)
		{
			var result = await _feedCategoryServices.GetFeedCategory(id);
			return View(result.Data);
		}

		[HttpGet("create-feedcategory")]
		public async Task<IActionResult> CreateFeedCategory()
		{
			return View();
		}

		[HttpPost("create-feedcategory")]
		public async Task<IActionResult> CreateFeedCategory([FromForm] CreateFeedCategoryDto request)
		{
			var result = await _feedCategoryServices.CreateFeedCategory(request);
			if (result.IsSuccessful)
			{
				return RedirectToAction("FeedCategories");
			}
			return RedirectToAction("CreateFeedCategory");
		}

		[HttpGet("update-feedcategory/{id}")]
		public async Task<IActionResult> UpdateFeedCategory([FromRoute] Guid id)
		{
			var result = await _feedCategoryServices.GetFeedCategory(id);
			return View(result.Data);
		}

		[HttpPost("update-feedcategory/{id}")]
		public async Task<IActionResult> UpdateFeedAsync([FromRoute] Guid id, [FromForm] UpdateFeedCategoryDto request)
		{
			var result = await _feedCategoryServices.UpdateFeedCategory(id, request);
			if (result.IsSuccessful)
			{
				return RedirectToAction("FeedCategoryDetail", new { id = id });
			}
			return RedirectToAction("FeedsCategories");
		}

		[HttpGet("delete-feedCategory/{id}")]
		public async Task<IActionResult> DeleteFeedAsync([FromRoute] Guid id)
		{
			var result = await _feedCategoryServices.DeleteFeedCategory(id);
			if (result.IsSuccessful)
			{
				return RedirectToAction("FeedCategories");
			}
			return RedirectToAction("DeleteFeedCategory");
		}
}
}

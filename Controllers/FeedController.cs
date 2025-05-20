
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QFeedmill.Shared.Models.Dto.Feed;
using QFeedmill.Shared.Services;

namespace QFeedMill.Controllers
{
    [Route("feed-production")]
	public class FeedController : Controller
	{
		private readonly IFeedServices _feedServices;
        private readonly IFeedCategoryServices _feedCategoryServices;
        private readonly INotyfService _notyf;
       

        public FeedController(IFeedServices feedServices, IFeedCategoryServices feedCategoryServices, INotyfService notyf)
        {
			_feedServices = feedServices;
            _feedCategoryServices = feedCategoryServices;
            _notyf = notyf;
        }
        [HttpGet("all-feeds")]
        public async Task<IActionResult> FeedsAsync()
		{
			var result = await _feedServices.GetAllFeeds();
			return View(result.Data);
		}

		[HttpGet("feed/{id}")]
		public async Task<IActionResult> FeedDetail([FromRoute] Guid id)
		{
			var result = await _feedServices.GetFeed(id);
			return View(result.Data);
		}
        [Authorize(Roles = "Admin")]
        [HttpGet("create-feed")]
		public async Task<IActionResult> CreateFeed()
		{
			var feedCategoies  = await _feedCategoryServices.GetAllFeedCategories();

            ViewData["selectFeedCategories"] = new SelectList(feedCategoies.Data, "Id", "Name");
            return View();
		}

		[HttpPost("create-feed")]
		public async Task<IActionResult> CreateFeed([FromForm] CreateFeedDto request)
		{
            TempData["NotificationMessage"] = "Form submitted successfully!";
            TempData["NotificationType"] = "success";
            var result = await _feedServices.CreateFeed(request);
			if (result.IsSuccessful)
			{
                _notyf.Success("Feed Created Sucessfully");
                return RedirectToAction("Feeds");
			}
            _notyf.Error("Feed created faiiled");
            return RedirectToAction("CreateFeed");
		}

		[HttpGet("update-feed/{id}")]
		public async Task<IActionResult> UpdateFeed([FromRoute] Guid id)
		{
            var feedCategories = await _feedCategoryServices.GetAllFeedCategories();
            ViewData["selectFeedCategories"] = new SelectList(feedCategories.Data, "Id", "Name");

            var result = await _feedServices.GetFeed(id);
			return View(result.Data);
		}

		[HttpPost("update-feed/{id}")]
		public async Task<IActionResult> UpdateFeedAsync([FromRoute] Guid id, [FromForm] UpdateFeedDto request)
		{
			var result = await _feedServices.UpdateFeed(id, request);
				if (result.IsSuccessful)
			{
				return RedirectToAction("FeedDetail", new { id = id });
			}
			return RedirectToAction("Feeds");
		}
        [Authorize(Roles = "Buyer")]
        [HttpGet("delete-feed/{id}")]
		public async Task<IActionResult> DeleteFeedAsync([FromRoute] Guid id)
		{
			var result = await _feedServices.DeleteFeed(id);
			if (result.IsSuccessful)
			{
				return RedirectToAction("Feeds");
			}
			return RedirectToAction("Feeds");
		}
	}
}

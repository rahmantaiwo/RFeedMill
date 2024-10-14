using Microsoft.AspNetCore.Mvc;
using QFeedMill.Models.Dto.Feed;
using QFeedMill.Services;

namespace QFeedMill.Controllers
{
    [Route("feed-production")]
	public class FeedController : Controller
	{
		private readonly IFeedServices _feedServices;
        public FeedController(IFeedServices feedServices)
        {
			_feedServices = feedServices;
        }

		[HttpGet("all-feeds")]
        public async Task<IActionResult> FeedsAsync()
		{
			var result = await _feedServices.GetAllFeeds();
			return View(result.Data);
		}

		[HttpGet("feed/{id}")]
		public async Task<IActionResult> FeedDetailAsync([FromRoute] Guid id)
		{
			var result = await _feedServices.GetFeed(id);
			return View(result.Data);
		}

		[HttpGet("create-feed")]
		public async Task<IActionResult> CreateFeed()
		{
			return View();
		}

		[HttpPost("create-feed")]
		public async Task<IActionResult> CreateFeedAsync([FromForm] CreateFeedDto request)
		{
			var result = await _feedServices.CreateFeed(request);
			if (result.IsSuccessful)
			{
				return RedirectToAction("Feeds");
			}
			return RedirectToAction("CreateFeed");
		}

		[HttpGet("update-feed/{id}")]
		public async Task<IActionResult> UpdateFeed([FromRoute] Guid id)
		{
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

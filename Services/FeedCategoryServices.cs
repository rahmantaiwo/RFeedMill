using Azure.Core;
using QFeedMill.Models.Category;
using QFeedMill.Models.Dto;
using QFeedMill.Models.Dto.Feed;
using QFeedMill.Models.Dto.FeedCategory;
using QFeedMill.Models.IRepository;
using QFeedMill.Models.IServices;
using QFeedMill.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QFeedMill.Services
{
    public class FeedCategoryServices : IFeedCategoryServices
	{
		private readonly IFeedCategoryRepository _feedCategoryRepository;
		private readonly ApplicationDbContext _dbContext;
		public FeedCategoryServices(IFeedCategoryRepository feedCategoryRepository, ApplicationDbContext dbContext)
		{
			_feedCategoryRepository = feedCategoryRepository;
			_dbContext = dbContext;
		}

		public async Task<BaseResponse<bool>> CreateFeedCategory(CreateFeedCategoryDto request)
		{
			try
			{
				var newFeedCategory = new FeedCategory()
				{
					Name = request.Name,
				};
				await _dbContext.FeedCategories.AddAsync(newFeedCategory);
				if (await _dbContext.SaveChangesAsync() > 0)
				{
					return new BaseResponse<bool> { Message = "FeedCategory created successful", IsSuccessful = true, Data = true };
				}
				return new BaseResponse<bool> { Message = "FeedCategory created failed", IsSuccessful = false, Data = false };
			}
			catch (Exception ex)
			{
				return new BaseResponse<bool> { Message = $"Error :  {ex.Message}", IsSuccessful = false, Data = false };
			}
		}

		public Task<BaseResponse<bool>> DeleteFeedCategory(Guid id)
		{
			throw new NotImplementedException();
		}

		public async Task<BaseResponse<List<FeedCategoryDto>>> GetAllFeedCategories()
		{
			try
			{
				var feedCategory = await _feedCategoryRepository.GetAllFeedCategoryAsync();
				if (feedCategory.Count > 0)
				{
					return new BaseResponse<List<FeedDto>> { Message = "No record", IsSuccessful = false, Data = data };
				}
				var data = feedCategory.Select(x => new FeedCategoryDto
				{
					Id = x.Id,
					Name = x.Name,
				}).ToList();
				return new BaseResponse<List<FeedCategoryDto>> { Message = "Data retrieved successfully", IsSuccessful = false, Data = data };
			}
			catch (Exception ex)
			{
				return new BaseResponse<List<FeedDto>> { Message = $"Error : {ex.Message}", IsSuccessful = false, Data =  };
			}
		}

		public async Task<BaseResponse<bool>> GetFeedCategory(Guid id)
		{
			try
			{ 
			var feedCategory = await _feedCategoryRepository.GetFeedCategoryAsync(id);
			if (feedCategory != null)
			{
				var data = new FeedCategoryDto
				{
					Name = feedCategory.Name
				};
				return new BaseResponse<bool> { Message = "Data retrieved succesful", IsSuccessful = false, Data = data };
				}
				return new BaseResponse<FeedDto> { Message = "No record", IsSuccessful = false, Data = new FeedDto() };
			}
			catch (Exception ex)
			{
				return new BaseResponse<FeedDto> { Message = $"Error : {ex.Message}", IsSuccessful = false, Data = new FeedDto() };
			}

		}

		public Task<BaseResponse<bool>> UpdateFeedCategory(Guid id, UpdateFeedCategoryDto request)
		{
			var feedCategory = _feedCategoryRepository.GetAllFeedCategoryAsync();
			if(feedCategory != null)
			{
				feedCategory.Name = request.Name;
				_dbContext.FeedCategories.Update(feedCategory);
			}
		}
	}

		

	
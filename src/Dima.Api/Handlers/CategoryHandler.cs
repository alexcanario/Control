using Dima.Api.Data;

namespace Dima.Api.Handlers;

public class CategoryHandler(AppDbContext Ctx) : ICategoryHandler
{
	public async Task<Response<Category>> CreateAsync(CreateCategoryRequest request)
	{
		var category = new Category
		{
			Title = request.Title,
			Description = request.Description,
			UserId = request.UserId
		};

		try
		{
			Ctx.Categories.Add(category);
			await Ctx.SaveChangesAsync();

			return new Response<Category>(category);
		}
		catch (Exception ex)
		{
			return new Response<Category>(category, message:ex.Message);
			throw;
		}
	}

	public Task<Response<Category>> UpdateAsync(UpdateCategoryRequest request)
	{
		throw new NotImplementedException();
	}

	public Task<Response<Category>> DeleteAsync(DeleteCategoryRequest request)
	{
		throw new NotImplementedException();
	}

	public Task<Response<IList<Category>>> GetAllAsync(GetAllCategoriesRequest request)
	{
		throw new NotImplementedException();
	}

	public Task<Response<Category>> GetByIdAsync(GetCategoryByIdRequest request)
	{
		throw new NotImplementedException();
	}
}
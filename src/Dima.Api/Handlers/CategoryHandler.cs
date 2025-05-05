using Dima.Api.Data;

using Microsoft.EntityFrameworkCore;

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

			return new Response<Category>(category, code: StatusCodes.Status201Created);
		}
		catch (Exception ex)
		{
			return new Response<Category>(category, message: ex.Message);
			throw;
		}
	}

	public async Task<Response<Category>> UpdateAsync(UpdateCategoryRequest request)
	{
		var category = await Ctx.Categories.Where(c => c.Id == request.Id && c.UserId == request.UserId)
			.FirstOrDefaultAsync();

		if (category == null)
			return new Response<Category>(null, code: StatusCodes.Status404NotFound, message: "Categoria não encontrada!");

		try
		{
			category.Title = request.Title;
			category.Description = request.Description;

			Ctx.Categories.Update(category);
			await Ctx.SaveChangesAsync();
			return new Response<Category>(category);
		}
		catch (Exception e)
		{
			// Log the exception (e.g., using Serilog, NLog, etc.)
			return new Response<Category>(null, code: StatusCodes.Status500InternalServerError,  "Não foi possível alterar a categoria.");
		}
	}

	public Task<Response<Category>> DeleteAsync(DeleteCategoryRequest request)
	{

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
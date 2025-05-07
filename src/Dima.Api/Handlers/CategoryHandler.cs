using Dima.Api.Data;

using Microsoft.EntityFrameworkCore;

namespace Dima.Api.Handlers;

public class CategoryHandler(AppDbContext ctx) : ICategoryHandler
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
			ctx.Categories.Add(category);
			await ctx.SaveChangesAsync();

			return new Response<Category>(category, code: StatusCodes.Status201Created);
		}
		catch (Exception ex)
		{
			return new Response<Category>(category, code: StatusCodes.Status500InternalServerError, message: ex.Message);
		}
	}

	public async Task<Response<Category?>> UpdateAsync(UpdateCategoryRequest request)
	{
		var category = await ctx.Categories.Where(c => c.Id == request.Id && c.UserId == request.UserId)
			.FirstOrDefaultAsync();

		if (category == null)
			return new Response<Category?>(null, code: StatusCodes.Status204NoContent, message: "Categoria não encontrada!");

		try
		{
			category.Title = request.Title;
			category.Description = request.Description;

			ctx.Categories.Update(category);
			await ctx.SaveChangesAsync();
			return new Response<Category?>(category, code: StatusCodes.Status200OK, "Categoria atualizada com sucesso.");
		}
		catch (Exception e)
		{
			// Log the exception (e.g., using Serilog, NLog, etc.)
			return new Response<Category?>(null, code: StatusCodes.Status500InternalServerError,  e.Message);
		}
	}

	public async Task<Response<Category?>> DeleteAsync(DeleteCategoryRequest request)
	{
		var category = await ctx.Categories.Where(c => c.Id == request.Id && c.UserId == request.UserId).FirstOrDefaultAsync();

		if (category is null)
			return new Response<Category?>(null, code: StatusCodes.Status204NoContent, message: "Categoria não encontrada!");
		try
		{
			ctx.Categories.Remove(category);
			await ctx.SaveChangesAsync();
			return new Response<Category?>(category, code: StatusCodes.Status200OK, "Categoria removida com sucesso.");
		}
		catch (Exception e)
		{
			// Log the exception (e.g., using Serilog, NLog, etc.)
			return new Response<Category?>(null, code: StatusCodes.Status500InternalServerError, message: e.Message);
		}
	}

	public async Task<Response<List<Category>?>> GetAllAsync(GetAllCategoriesRequest request)
	{

		var categories = await ctx.Categories.AsNoTracking().Where(c => c.UserId == request.UserId).ToListAsync();

		return categories.Count == 0
			? new Response<List<Category>?>(categories, code: StatusCodes.Status204NoContent,
				"Não há categorias para exibir")
			: new Response<List<Category>?>(categories, code: StatusCodes.Status200OK);
	}

	public async Task<Response<Category?>> GetByIdAsync(GetCategoryByIdRequest request)
	{
		var category = await ctx.Categories.AsNoTracking()
			.Where(c => c.Id == request.Id && c.UserId == request.UserId)
			.FirstOrDefaultAsync();

		return category is null
			? new Response<Category?>(null, code: StatusCodes.Status204NoContent, message: "Categoria não encontrada!")
			: new Response<Category?>(category);
	}
}
using Dima.Api.Data;
using Dima.Core.Requests.Transactions;
using Dima.Core.Common;

using Microsoft.EntityFrameworkCore;

namespace Dima.Api.Handlers;

public class TransactionHandler(AppDbContext context) : ITransactionHandler
{
	public async Task<Response<Transaction?>> CreateAsync(CreateTransactionRequest request)
	{
		var transaction = Transaction.Create(
			request.Title, request.Type, request.Amount,
			request.CategoryId, request.PaidOrReceivedAt, request.UserId);


		try
		{
			await context.Transactions.AddAsync(transaction);
			await context.SaveChangesAsync();

			return new Response<Transaction?> { Data = transaction };
		}
		catch
		{
			return new Response<Transaction?>(null, StatusCodes.Status500InternalServerError, "Não foi possível criar a sua transação");
		}

	}

	public async Task<Response<Transaction?>> UpdateAsync(UpdateTransactionRequest request)
	{
		var transaction = await context.Transactions.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

		if (transaction is null)
		{
			return new Response<Transaction?>(null, "Transação não encontrada.");
		}

		transaction.Update(request.Title, request.Type, request.Amount, request.CategoryId, request.PaidOrReceivedAt);

		try
		{
			context.Transactions.Update(transaction);
			await context.SaveChangesAsync();
			return new Response<Transaction?> { Data = transaction, Message = $"Transação {request.Id} atualizada com sucesso." };
		}
		catch (Exception e)
		{
			//logging erro
			return new Response<Transaction?>(null, StatusCodes.Status500InternalServerError, e.Message);
		}
	}

	public async Task<Response<Transaction?>> DeleteAsync(DeleteTransactionRequest request)
	{
		var transaction = await context.Transactions.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

		if (transaction is null)
		{
			return new Response<Transaction?>(null, "Transação não encontrada.");
		}

		try
		{
			context.Transactions.Remove(transaction);
			await context.SaveChangesAsync();
			return new Response<Transaction?> { Data = transaction, Message = $"Transação {request.Id} removida com sucesso." };
		}
		catch (Exception e)
		{
			//logging erro
			return new Response<Transaction?>(null, StatusCodes.Status500InternalServerError, e.Message);
		}
	}

	public async Task<Response<Transaction?>> GetByIdAsync(GetTransactionByIdRequest request)
	{
		try
		{
			var transaction =
				await context.Transactions.FirstOrDefaultAsync(t => t.UserId == request.UserId && t.Id == request.Id);
			return transaction is not null
				? new Response<Transaction?> { Data = transaction }
				: new Response<Transaction?>(null, "Transação não encontrada.");
		}
		catch
		{
			//logging erro
			return new Response<Transaction?>(null, StatusCodes.Status500InternalServerError, "Ocorreu um erro ao buscar a transação, tente novamente mais tarde");
		}
	}

	public async Task<PagedResponse<IEnumerable<Transaction>?>> GetByPeriodAsync(GetTransactionsByPeriodRequest request)
	{
		try
		{
			request.StartDate ??= DateTime.Now.GetFirstDay();
			request.EndDate ??= DateTime.Now.GetLastDay();
		}
		catch
		{
			//logging erro
			return new PagedResponse<IEnumerable<Transaction>?>(null, StatusCodes.Status400BadRequest,
				"Não foi possível determinar o período");
		}

		var query = context.Transactions
			.AsNoTracking()
			.Where(t => t.CreatedAt >= request.StartDate && t.CreatedAt <= request.EndDate &&
			            t.UserId == request.UserId)
			.OrderBy(t => t.Title);

		var totalCount = await query.CountAsync();

		try
		{
			var transactions = await query
				.Skip(request.PageSize * (request.PageNumber - 1))
				.Take(request.PageSize)
				.ToListAsync();

			return new PagedResponse<IEnumerable<Transaction>?>(transactions, totalCount, request.PageNumber,
				request.PageSize);
		}
		catch
		{
			//logging erro
			return new PagedResponse<IEnumerable<Transaction>?>(null, StatusCodes.Status500InternalServerError, "Não foi possível retornar as transações");
		}
	}
}
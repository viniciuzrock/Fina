using Fina.Core.Models;
using Fina.Core.Requests.Transactions;
using Fina.Core.Response;

namespace Fina.Core.Handlers;

public interface ITransactionHandler
{
    Task<Response<Transaction?>> CreateAsync(CreateTransactionRequest request);
    Task<Response<Transaction?>> UpdateAsync(UpdateTransactionsRequest request);
    Task<Response<Transaction>> DeleteAsync(DeleteTransactionRequest request);
    Task<PagedResponse<Transaction?>> GetByIdAsync(GetTransactionByIdRequest request);
    Task<PagedResponse<List<Transaction>?>> GetByPeriodAsync(GetTransactionsByPeriodRequest request);
}
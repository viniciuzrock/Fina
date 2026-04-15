using Fina.Api;
using Fina.Api.Common.Api;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Transactions;
using Fina.Core.Response;

namespace Fina.Api.Endpoints.Transactions;

public class UpdateTransactionEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder builder)
    {
        builder.MapPut("/{id}", HandleAsync)
            .WithName("UpdateTransaction")
            .WithDescription("Updates a new transaction")
            .WithSummary("Updates a new transaction")
            .WithOrder(4)
            .Produces<Response<Transaction?>>();
    }
    
    private static async Task<IResult> HandleAsync( ITransactionHandler handler, UpdateTransactionsRequest request, Guid id)
    {
        request.UserId = ApiConfiguration.UserId;
        request.Id = id;
        var result = await handler.UpdateAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}

    


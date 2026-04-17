using Fina.Api.Common.Api;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Transactions;
using Fina.Core.Response;
using Microsoft.AspNetCore.Mvc;

namespace Fina.Api.Endpoints.Transactions;

public class GetTransactionByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder builder)
    {
        builder.MapGet("/{id}", HandleAsync)
            .WithName("GetTransactionById")
            .WithSummary("Gets a Transaction by id")
            .WithDescription("Gets a Transaction by id")
            .Produces<Response<Transaction?>>();
    }

    private static async Task<IResult> HandleAsync(ITransactionHandler handler, [FromQuery] Guid transactionId)
    {
        var request = new GetTransactionByIdRequest
        {
            UserId = ApiConfiguration.UserId,
            Id = transactionId,
        };

        var result = await handler.GetByIdAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
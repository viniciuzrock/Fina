using Fina.Api.Common.Api;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Transactions;
using Fina.Core.Response;

namespace Fina.Api.Endpoints.Transactions;

public class CreateTransactionEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder builder)
    {
        builder.MapPost("/", HandleAsync)
            .WithName("CreateTransaction")
            .WithDescription("Creates a new transaction")
            .WithSummary("Creates a new transaction")
            .WithOrder(1)
            .Produces<Response<Transaction?>>();
    }

    private static async Task<IResult> HandleAsync(ITransactionHandler handler, CreateTransactionRequest request)
    {
        request.UserId = ApiConfiguration.UserId;
        var result = await handler.CreateAsync(request);
        return result.IsSuccess
            ? Results.Created($"v1/categories/{result.Data?.Id}", result)
            : Results.BadRequest(result);
    }
}
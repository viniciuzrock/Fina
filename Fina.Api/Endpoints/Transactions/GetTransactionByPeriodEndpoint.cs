using Fina.Api.Common.Api;
using Fina.Core;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Transactions;
using Fina.Core.Response;
using Microsoft.AspNetCore.Mvc;

namespace Fina.Api.Endpoints.Transactions
{
    public class GetTransactionByPeriodEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder builder)
        {
            builder.MapGet("/period", HandleAsync)
                .WithName("List for period")
                .WithDescription("list for period")
                .WithSummary("list of 3")
                .WithOrder(2)
                .Produces<PagedResponse<List<Transaction>?>>();
        }

        private static async Task<IResult> HandleAsync(
            ITransactionHandler handler, 
            [FromQuery] DateTime? startDate = null, 
            [FromQuery] DateTime? endDate = null,
            [FromQuery] int PageNumber = Configuration.DefaultPageNumber,
            [FromQuery] int PageSize = Configuration.DefaultPageSize)
        {
            var request = new GetTransactionsByPeriodRequest
            {
                UserId = ApiConfiguration.UserId,
                EndDate = endDate,
                StartDate = startDate,
                PageNumber = PageNumber,
                PageSize = PageSize
            };
            var result = await handler.GetByPeriodAsync(request);
            return result.IsSuccess 
                ? TypedResults.Ok(result) 
                : TypedResults.BadRequest(result);
        }
    }
}

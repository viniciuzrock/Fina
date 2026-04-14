using System.Security.Claims;
using Fina.Api.Common.Api;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Response;
using Microsoft.AspNetCore.DataProtection.Repositories;

namespace Fina.Api.Endpoints.Categories
{
    public class DeleteCategoryEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder builder)
        {
            builder.MapDelete("/{id}", HandleAsync)
                .WithName("DeleteCategory")
                .WithSummary("Deletes a Category")
                .WithDescription("Deletes a Category")
                .WithOrder(3)
                .Produces<Response<Category?>>();
                
        }

        private static async Task<IResult> HandleAsync(
            //ClaimsPrincipal user, pega o usuário logado
            ICategoryHandler handler,
            Guid id)
        {
            var request = new DeleteCategoryRequest
            {
                UserId = ApiConfiguration.UserId,
                Id = id
            };
                
            var response = await handler.DeleteAsync(request);
            return response.IsSuccess
                ? TypedResults.Ok(response)
                : TypedResults.BadRequest(response);
        }
    }
}

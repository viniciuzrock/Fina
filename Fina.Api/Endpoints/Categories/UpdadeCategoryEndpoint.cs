using System.Reflection.Metadata;
using Fina.Api.Common.Api;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Response;
using Microsoft.AspNetCore.Mvc;

namespace Fina.Api.Endpoints.Categories;

public class UpdadeCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder builder)
    {
        builder.MapPatch("/{id}", HandleAsync)
            .WithName("UpdateCategory")
            .WithTags("Category")
            .WithSummary("Update a Category")
            .WithDescription("Update a Category")
            .WithOrder(2)
            .Produces<Response<Category?>>();
    }

    private static async Task<IResult> HandleAsync(ICategoryHandler handler, UpdateCategoryRequest request, Guid id)
    {
        var response = await handler.UpdateAsync(request);
        return response.IsSuccess
            ? Results.Ok(response)
            : Results.BadRequest(response);
    }
}
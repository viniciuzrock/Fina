using Fina.Api.Common.Api;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Response;

namespace Fina.Api.Endpoints.Categories;

public class CreateCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder builder) 
        => builder.MapPost("/", HandleAsync)
            .WithName("CreateCategoryv4")
            .WithSummary("Creates a new Categoryv3")
            .WithDisplayName("Create Categoryv2")
            .WithOrder(1)
            .Produces<Response<Category?>>();

    private static async Task<IResult> HandleAsync(ICategoryHandler handler, CreateCategoryRequest request)
    {
        request.UserId = ApiConfiguration.UserId;
        var response = await handler.CreateAsync(request);
        return response.IsSuccess
            ? TypedResults.Created($"v1/categories/{response.Data?.Id}", response.Data)
            : TypedResults.BadRequest();
    }
}
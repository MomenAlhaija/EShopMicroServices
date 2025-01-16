using Microsoft.AspNetCore.Components;
using NetTopologySuite.Index.Quadtree;

namespace Catalog.API.Products;
public record GetProdcutRequest(int Page=1,int Size=10);
public record GetProductsResponse(IEnumerable<Product> Products); 
public class GetProductsEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async ([AsParameters]GetProdcutRequest request,ISender sender) =>
        {
            var query = new GetProductsQuer { Page=request.Page,Size=request.Size};
            var result = await sender.Send(query);
            var response = result.Adapt<GetProductsResponse>();
            return Results.Ok(response);
        })
        .WithName("GetProduct")
        .Produces<GetProductsResult>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Products")
        .WithDescription("GetProducts");
    }
}

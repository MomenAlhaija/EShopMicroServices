
namespace Catalog.API.Products;

public class GetProductByCategoryEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/category/{name}", async (string name, ISender sender) =>
        {
            var query = new GetProductByCategoryQuery(name);
            var result = await sender.Send(query);
            var response = result.Adapt<GetProductsResult>();
            return Results.Ok(response);
        })
       .WithName("GetProductsByCategory")
       .Produces<GetProductsResult>(StatusCodes.Status200OK)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .WithSummary("Get Products By Category")
       .WithDescription("GetProductsByCategory");
    }
}

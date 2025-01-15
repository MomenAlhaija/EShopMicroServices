namespace Catalog.API.Products;

public record GetProoductsResult(IEnumerable<Product> Products); 
public class GetProductsEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async (ISender sender) =>
        {
            var query = new GetProductsQuer();
            var result = await sender.Send(query);
            var response = result.Adapt<GetProoductsResult>();
            return Results.Ok(response);
        })
        .WithName("GetProduct")
        .Produces<GetProductsResult>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Products")
        .WithDescription("GetProducts");
    }
}

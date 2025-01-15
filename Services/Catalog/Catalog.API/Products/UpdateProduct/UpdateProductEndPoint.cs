namespace Catalog.API.Products;
public record UpdateProductRequest(Guid Id,string Name, string Description, decimal Price, string ImageFile, List<string> Category);
public record UpdateProductResponse(Product Product);
public class UpdateProductEndPoint:ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/products", async (UpdateProductRequest reqest, ISender sender) =>
        {
            var command = reqest.Adapt<UpdateProductCommand>();
            var result = await sender.Send(command);
            var response = result.Adapt<UpdateProductResponse>();
            return Results.Ok(response);
        })
        .WithName("UpdateProduct")
        .Produces<UpdateProductResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Product")
        .WithDescription("UpdateProduct");

    }
}

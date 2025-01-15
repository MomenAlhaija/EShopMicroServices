namespace Catalog.API.Products;
public record DeleteProductRequest(Guid Id);
public record DeleteProductRsponse(bool IsSuccess);
public class DeleteProductEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/products/{Id}", async (Guid Id, ISender sender) =>
        {
            var command = new DeleteProductCommand(Id);
            var result = await sender.Send(command);
            var response = result.Adapt<DeleteProductRsponse>();
            return Results.Ok(response);
        })
        .WithName("DeleteProduct")
        .Produces<CreateProductResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Delete Product")
        .WithDescription("DeleteProduct");

    }

}


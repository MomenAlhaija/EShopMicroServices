namespace Catalog.API;
public record CreateProductRequest(string Name,string Description, decimal Price, string ImageFile,List<string> Category);
public record CreateProductResponse(Guid Id);
public class CreateProductEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products", async (CreateProductRequest reqest, ISender sender) =>
        {
            var command = reqest.Adapt<CreateProductCommand>();
            var result = await sender.Send(command);
            var response = result.Adapt<CreateProductResult>();
            return Results.Created($"/products/{response.Id}", response);
        })
        .WithName("CreateProduct")
        .Produces<CreateProductResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Product")
        .WithDescription("CreateProduct");
        
       
    }
}

namespace Catalog.API;

public record CreateProductCommand(string Name, string Description, decimal Price, string ImageFile, List<string> Category): ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);
public class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        //Create Product 
        var product = new Product
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            ImageFile = request.ImageFile,
            Category = request.Category,
        };

        //Save In DB
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);

        //Return Result
        return new CreateProductResult(Guid.NewGuid());
    }
}

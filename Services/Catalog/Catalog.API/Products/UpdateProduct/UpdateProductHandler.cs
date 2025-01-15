using Catalog.API.Exceptions;

namespace Catalog.API.Products;
public record UpdateProductCommand(Guid Id, string Name, string Description, decimal Price, string ImageFile, List<string> Category) :ICommand<UpdateProoductResult>;
public record UpdateProoductResult(Product  Product);
public class UpdateProductHandler(IDocumentSession session) : ICommandHandler<UpdateProductCommand, UpdateProoductResult>
{
    public async Task<UpdateProoductResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(request.Id, cancellationToken);
        
        if(product is null)
            throw new ProductNotFoundException(request.Id);

        product.Name= request.Name; 
        product.Description= request.Description;
        product.Price= request.Price;
        product.ImageFile= request.ImageFile;
        product.Category= request.Category;
        session.Update(product);
        
        await session.SaveChangesAsync();
        return new UpdateProoductResult(product);
    }
}

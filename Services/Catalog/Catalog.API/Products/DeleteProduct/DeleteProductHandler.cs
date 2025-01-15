
namespace Catalog.API.Products;
public record DeleteProductCommand(Guid Id) : ICommand<DelteProductResult>;
public record DelteProductResult(bool IsSuccess);
public class DeleteProductHandler(IDocumentSession session) : ICommandHandler<DeleteProductCommand, DelteProductResult>
{
    public async Task<DelteProductResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        session.Delete<Product>(request.Id);
        await session.SaveChangesAsync();
        return new DelteProductResult(true);
    }
}

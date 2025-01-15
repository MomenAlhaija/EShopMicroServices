

namespace Catalog.API.Products;
public record GetProductByIdQuery(Guid Id):IQuery<GetProductByIdResult>;
public record GetProductByIdResult(Product Product);
public class GetProductByIdHandler(IDocumentSession session) : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(request.Id, cancellationToken);
        return new GetProductByIdResult(product);

    }
}

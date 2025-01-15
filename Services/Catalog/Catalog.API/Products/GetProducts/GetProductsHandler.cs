
namespace Catalog.API.Products;
public record GetProductsQuer():IQuery<GetProductsResult>;
public record GetProductsResult(IEnumerable<Product> Products);
public class GetProductsHandler(IDocumentSession session) : IQueryHandler<GetProductsQuer, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsQuer request, CancellationToken cancellationToken)
    {
        var products=await session.Query<Product>().ToListAsync(cancellationToken);
        return new GetProductsResult(products);
    }

}

using Marten.Linq.QueryHandlers;

namespace Catalog.API.Products;
public record GetProductByCategoryQuery(string Name):IQuery<GettProductByCategoryResult>;
public record GettProductByCategoryResult(IEnumerable<Product> Products);
public class GetProductByCategoryHandler(IDocumentSession session)
    : IQueryHandler<GetProductByCategoryQuery, GettProductByCategoryResult>
{
    public async Task<GettProductByCategoryResult> Handle(GetProductByCategoryQuery request, CancellationToken cancellationToken)
    {
        var Products = await session.Query<Product>().Where(p => p.Category.Contains(request.Name)).ToListAsync();
        return new GettProductByCategoryResult(Products);
    }
}

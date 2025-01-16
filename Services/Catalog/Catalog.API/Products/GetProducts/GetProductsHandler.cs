
using Marten.Pagination;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Catalog.API.Products;
public record GetProductsQuer(int Page = 1, int Size = 10) :IQuery<GetProductsResult>;
public record GetProductsResult(IEnumerable<Product> Products);
public class GetProductsHandler(IDocumentSession session) : IQueryHandler<GetProductsQuer, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsQuer request, CancellationToken cancellationToken)
    {
        var products=await session.Query<Product>().ToPagedListAsync
            (request.Page,request.Size,cancellationToken);
        return new GetProductsResult(products);
    }

}

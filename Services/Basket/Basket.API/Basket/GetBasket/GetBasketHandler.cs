namespace Basket.API.Basket;
public record GetBasketQuery(string UserName):IQuery<GetBasketResult>;
public record GetBasketResult(ShoppingCart ShoppingCart);
public class GetBasketHandler(IBasketRepository repository) :IQueryHandler<GetBasketQuery, GetBasketResult>
{
    public async Task<GetBasketResult> Handle(GetBasketQuery request, CancellationToken cancellationToken)
    {
        var shoppingCart = await repository.GetBasket(request.UserName,cancellationToken);
        return new GetBasketResult(shoppingCart);
    }
}

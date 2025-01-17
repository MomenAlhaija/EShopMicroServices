namespace Basket.API.Basket;
public record StoreBasketCommand(ShoppingCart ShoppingCart):ICommand<StoreBasketResult>;
public record StoreBasketResult(string UserName);
public class StoreBasketHandler(IBasketRepository repository) : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand request, CancellationToken cancellationToken)
    {
        await repository.StoreBasket(request.ShoppingCart,cancellationToken);
        return new StoreBasketResult(request.ShoppingCart.UserName);
    }
}

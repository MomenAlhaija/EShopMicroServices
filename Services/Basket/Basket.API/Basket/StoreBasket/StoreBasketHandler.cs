using Discount.Grpc;

namespace Basket.API.Basket;
public record StoreBasketCommand(ShoppingCart ShoppingCart):ICommand<StoreBasketResult>;
public record StoreBasketResult(string UserName);
public class StoreBasketHandler(IBasketRepository repository, DiscountProtoService.DiscountProtoServiceClient discountProto) : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand request, CancellationToken cancellationToken)
    {
        await DeductDiscount(request.ShoppingCart,cancellationToken);
        await repository.StoreBasket(request.ShoppingCart,cancellationToken);
        return new StoreBasketResult(request.ShoppingCart.UserName);
    }
    private async Task DeductDiscount(ShoppingCart cart, CancellationToken cancellationToken)
    {
        // Communicate with Discount.Grpc and calculate lastest prices of products into sc
        foreach (var item in cart.Items)
        {
            var coupon = await discountProto.GetDiscountAsync(new GetDiscountRequest { ProductName = item.ProductName }, cancellationToken: cancellationToken);
            item.Price -= coupon.Amount;
        }
    }
}

namespace Basket.API.Basket;

public class StoreBasketValidator:AbstractValidator<StoreBasketCommand>
{
    public StoreBasketValidator()
    {
        RuleFor(x => x.ShoppingCart).NotNull().WithMessage("Cart Can't Be Null");
        RuleFor(x => x.ShoppingCart.UserName).NotEmpty().WithMessage("USer Name Is Required");
    }
}

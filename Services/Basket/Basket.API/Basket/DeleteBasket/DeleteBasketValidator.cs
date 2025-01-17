namespace Basket.API.Basket;
public class DeleteBasketValidator:AbstractValidator<DeleteBasketCommand>   
{
    public DeleteBasketValidator()
    {
       RuleFor(c=>c.UserName).NotEmpty().WithMessage("User Name Is Required");
    }
}

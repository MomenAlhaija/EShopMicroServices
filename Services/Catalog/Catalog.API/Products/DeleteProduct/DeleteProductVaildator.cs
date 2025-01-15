namespace Catalog.API.Products;

public class DeleteProductVaildator:AbstractValidator<DeleteProductCommand>
{
    public DeleteProductVaildator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id Is Required");
    }

}

namespace Catalog.API.Products;

public class CreateProductValidator:AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(x=>x.Name).NotEmpty().WithMessage("Name IS Required");
        RuleFor(x=>x.Category).NotEmpty().WithMessage("Category Is Required");
        RuleFor(x => x.Price).NotEmpty().GreaterThan(0).WithMessage("Price Is Required and Must  Greater than Zero");
        RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile Is Required");

    }
}

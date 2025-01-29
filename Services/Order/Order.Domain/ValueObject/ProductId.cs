namespace Order.Domain.ValueObject;

public record ProductId
{
    public Guid Value { get; }

    private ProductId(Guid value)=>Value=value;

    public static ProductId Of(Guid value)
    {
        if (value == Guid.Empty)
            throw new DomainException("Producct Id Can't be Empty");

        return new ProductId(value);    
    }

}

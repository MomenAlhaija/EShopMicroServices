namespace Order.Domain.ValueObject;

public record OrderName
{
    public const int DefaultLength = 2;
    public string Value { get;}    

    private OrderName(string value)=>Value= value;

    public static OrderName Of(string value)
    {
        ArgumentException.ThrowIfNullOrEmpty(value);
        ArgumentOutOfRangeException.ThrowIfNotEqual(value.Length, DefaultLength);   

        return new OrderName(value);    

    }

}

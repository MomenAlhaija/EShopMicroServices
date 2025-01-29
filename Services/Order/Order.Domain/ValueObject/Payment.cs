namespace Order.Domain.ValueObject;

public record Payment
{
    public string? CardName { get; private set; } = default!;
    public string CardNumber { get; private set; } = default!;  
    public string Expiration { get; private set; } = default!;
    public string CVV { get; } = default!;
    public int PaymentMethod { get; } = default!;

    protected Payment()
    {

    }
    private Payment(string cardName, string cardNumber, string expiration, string cvv, int paymentMethod)
    {
        CardName = cardName;
        CardNumber = cardNumber;    
        Expiration = expiration;
        CVV = cvv;
        PaymentMethod = paymentMethod;
    }
    public static Payment Of(string cardName,string  cardNumber,string expiration,string cvv,int paymentMethod)
    {
        ArgumentException.ThrowIfNullOrEmpty(cardName);
        ArgumentException.ThrowIfNullOrEmpty(cardNumber);
        ArgumentException.ThrowIfNullOrEmpty(cvv);
        ArgumentOutOfRangeException.ThrowIfNotEqual(cvv.Length, 3);

        return new Payment(cardName, cardNumber, expiration, cvv, paymentMethod);
    }
}

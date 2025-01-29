namespace Order.Domain.ValueObject;

public record Address
{
    public string FirstName { get; private set; } = default!;
    public string LastName { get; private set; } = default!;
    public string Email { get; private set; } = default!;
    public string AddressLine { get; private set; } = default!;      
    public string Country { get; private set; } = default!; 
    public string State { get; private set; } = default!;   
    public string ZipCode { get; private set; } = default!;
    public Address()
    {
            
    }
    private Address(string firstName,string lastName,string email,string addressLine,string country,string state,string zipCode)
    {
        FirstName = firstName;  
        LastName = lastName;    
        Email = email;
        AddressLine = addressLine;
        Country = country;
        State = state;
        ZipCode = zipCode;
    } 

    public static Address Of(string firstName, string lastName, string email, string addressLine, string country, string state, string zipCode)
    {
        ArgumentException.ThrowIfNullOrEmpty(email);
        ArgumentException.ThrowIfNullOrEmpty(addressLine);

        return new Address(firstName, lastName, email, addressLine, country, state, zipCode);    
    }
}

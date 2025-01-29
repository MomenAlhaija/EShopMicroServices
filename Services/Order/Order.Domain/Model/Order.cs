using Order.Domain.Events;

namespace Order.Domain.Model;

public class Order:Aggregate<OrderId>
{
    private readonly List<OrderItem> _orderItems = new();

    public IReadOnlyList<OrderItem> OrderItems=> _orderItems.AsReadOnly();

    public CustomerId CustomerId { get; private set; } = default!;

    public OrderName OrderName { get; private set; } = default!;

    public Address ShippingAddress { get; private set; } = default!;

    public Address BillingAddress { get; private set; } = default!;

    public Payment Payment { get; private set; } = default!;

    public OrderStatus OrderStatus { get; private set; } = OrderStatus.Pending;

    public decimal TotalPrice { 
        get => _orderItems.Sum(oi => oi.Price * oi.Quantity); 
        private set { } 
    }

    public static Order Create(OrderId orderId, CustomerId customerId, OrderName orderName, Address shippingAddress, Address billingAddress, Payment payment)
    {
        var order = new Order
        {
            Id = orderId,
            CustomerId = customerId,
            OrderName = orderName,
            ShippingAddress = shippingAddress,
            BillingAddress = billingAddress,
            Payment = payment,
            OrderStatus = OrderStatus.Pending

        };

        order.AddDomainEvent(new OrderCreatedEvent(order)); 

        return order;   
    }


    public  void Update(OrderName orderName, Address shippingAddress, Address billingAddress, Payment payment,OrderStatus orderStatus)
    {

        OrderName = orderName;
        ShippingAddress = shippingAddress;
        BillingAddress = billingAddress;
        Payment = payment;
        OrderStatus = orderStatus;

        AddDomainEvent(new OrderUpdatedEvent(this));

    }

    public void Add(ProductId productId,decimal price,int quantity)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);


        _orderItems.Add(new OrderItem(Id, productId,quantity,price));
    }

    public void Remove(ProductId productId)
    {
        var orderItem=_orderItems.FirstOrDefault(p=>p.ProductId == productId);
        if (orderItem != null)
        {
            _orderItems.Remove(orderItem);
        }
    }
}

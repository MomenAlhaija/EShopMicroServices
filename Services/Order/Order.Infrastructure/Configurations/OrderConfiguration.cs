namespace Order.Infrastructure.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Domain.Model.Order>
{
    public void Configure(EntityTypeBuilder<Domain.Model.Order> builder)
    {
        builder.HasKey(order => order.Id);

        builder.Property(order => order.Id)
                .HasConversion(order => order.Value,
                dbId => OrderId.Of(dbId));

        builder.HasOne<Customer>()
                .WithMany()
                .HasForeignKey(order => order.CustomerId)
                .IsRequired();

        builder.HasMany(o => o.OrderItems)
            .WithOne()
            .HasForeignKey(oi => oi.OrderId);

        builder.ComplexProperty(order => order.OrderName, nameBuilder =>
        {
            nameBuilder.Property(n => n.Value)
                       .HasColumnName(nameof(Domain.Model.Order.OrderName))
                       .HasMaxLength(100)
                       .IsRequired();
        });

        builder.ComplexProperty(order => order.BillingAddress, addressBuilder =>
        {
            addressBuilder.Property(address=>address.FirstName)
                          .HasMaxLength(50)
                          .IsRequired();

            addressBuilder.Property(address => address.LastName)
                          .HasMaxLength(50)
                          .IsRequired();

            addressBuilder.Property(address=>address.Email)
                          .HasMaxLength(50)
                          .IsRequired();

            addressBuilder.Property(address => address.AddressLine)
                          .HasMaxLength(50)
                          .IsRequired();

            addressBuilder.Property(address => address.Country)
                          .HasMaxLength(50);

            addressBuilder.Property(address => address.State)
                          .HasMaxLength(50);

            addressBuilder.Property(address => address.ZipCode)
                          .HasMaxLength(50)
                          .IsRequired();
        });

        builder.ComplexProperty(order => order.ShippingAddress, addressBuilder =>
        {
            addressBuilder.Property(address => address.FirstName)
                          .HasMaxLength(50)
                          .IsRequired();

            addressBuilder.Property(address => address.LastName)
                          .HasMaxLength(50)
                          .IsRequired();

            addressBuilder.Property(address => address.Email)
                          .HasMaxLength(50)
                          .IsRequired();

            addressBuilder.Property(address => address.AddressLine)
                          .HasMaxLength(50)
                          .IsRequired();

            addressBuilder.Property(address => address.Country)
                          .HasMaxLength(50);

            addressBuilder.Property(address => address.State)
                          .HasMaxLength(50);

            addressBuilder.Property(address => address.ZipCode)
                          .HasMaxLength(50)
                          .IsRequired();
        });

        builder.ComplexProperty(order => order.Payment, paymentBuilder =>
        {

            paymentBuilder.Property(pay => pay.CardName)
                          .HasMaxLength(50);

            paymentBuilder.Property (pay => pay.CardNumber)
                           .HasMaxLength(24)
                           .IsRequired();

            paymentBuilder.Property(pay => pay.Expiration)
                           .HasMaxLength(10);

            paymentBuilder.Property(pay => pay.CVV)
                          .HasMaxLength(3);

            paymentBuilder.Property(pay => pay.PaymentMethod);
        });

        builder.Property(order => order.OrderStatus)
                        .HasDefaultValue(OrderStatus.Draft)
                        .HasConversion(s => s.ToString(), dbStatus => 
                         (OrderStatus)Enum.Parse(typeof(OrderStatus), dbStatus));

        builder.Property(order => order.TotalPrice);
    }



}

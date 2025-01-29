﻿namespace Order.Infrastructure.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(orderItem => orderItem.Id);

        builder.Property(orderItem => orderItem.Id)
                .HasConversion(orderItem => orderItem.Value,
                dbId => OrderItemId.Of(dbId));

        builder.HasOne<Product>()
               .WithMany()
               .HasForeignKey(orderItem => orderItem.ProductId);

        builder.Property(orderItem => orderItem.Price)
               .IsRequired();

        builder.Property(orderItem => orderItem.Quantity)
                .IsRequired();


    }
}

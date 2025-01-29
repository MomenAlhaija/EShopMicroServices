namespace Order.Infrastructure.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {

        builder.HasKey(cust=>cust.Id);

        builder.Property(cust => cust.Id)
                .HasConversion(cust => cust.Value,
                dbId => CustomerId.Of(dbId));

        builder.Property(cust => cust.Name)
               .IsRequired()
               .HasMaxLength(100);


        builder.Property(cust=>cust.Email)
               .HasMaxLength(100);

        builder.HasIndex(cust => cust.Email)
               .IsUnique();
    }
}

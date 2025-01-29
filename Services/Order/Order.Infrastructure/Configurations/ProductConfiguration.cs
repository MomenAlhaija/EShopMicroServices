namespace Order.Infrastructure.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(prod => prod.Id);

        builder.Property(prod => prod.Id)
                .HasConversion(prod => prod.Value,
                dbId => ProductId.Of(dbId));

        builder.Property(prod => prod.Name)
                .IsRequired()
                .HasMaxLength(100);
    }
}

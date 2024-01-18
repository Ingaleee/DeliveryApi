using DeliveryApi.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeliveryApi.Domain.Configurations
{
    public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.SenderCity).IsRequired();
            builder.Property(e => e.SenderAddress).IsRequired();
            builder.Property(e => e.RecipientCity).IsRequired();
            builder.Property(e => e.RecipientAddress).IsRequired();
            builder.Property(e => e.Weight).IsRequired();
            builder.Property(e => e.PickupDate).IsRequired();
        }
    }
}

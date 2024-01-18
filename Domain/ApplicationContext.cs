using DeliveryApi.Domain.Configurations;
using DeliveryApi.Types;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApi.Domain
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new OrderEntityConfiguration());
        }
    }
}

using ModelOrder = Company.Services.Model.Order;
using Microsoft.EntityFrameworkCore;
using System;

namespace Company.Services.Order.Repository
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options) 
        {
            this.Database.EnsureCreated();
        }

        public virtual DbSet<ModelOrder.Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModelOrder.Order>()
                .HasData(
                    new ModelOrder.Order(Guid.NewGuid(), 10, new Guid("220e7528-3cd7-493b-9ab3-d7f369bdb3dc")),
                    new ModelOrder.Order(Guid.NewGuid(), 20, new Guid("220e7528-3cd7-493b-9ab3-d7f369bdb3dc")),
                    new ModelOrder.Order(Guid.NewGuid(), 30, new Guid("220e7528-3cd7-493b-9ab3-d7f369bdb3dc")),
                    new ModelOrder.Order(Guid.NewGuid(), 150, new Guid("b8b55a7b-c18a-4ee4-964b-f8f22bf93663")),
                    new ModelOrder.Order(Guid.NewGuid(), 250, new Guid("b8b55a7b-c18a-4ee4-964b-f8f22bf93663")),
                    new ModelOrder.Order(Guid.NewGuid(), 13, new Guid("8fcf47f5-b08b-4f3c-a78f-38b0ffedc822")),
                    new ModelOrder.Order(Guid.NewGuid(), 7, new Guid("f3a5e45f-c627-4588-8c76-9ce908c44fd8")),
                    new ModelOrder.Order(Guid.NewGuid(), 30, new Guid("f3a5e45f-c627-4588-8c76-9ce908c44fd8")),
                    new ModelOrder.Order(Guid.NewGuid(), 1000, new Guid("d131e104-6ddc-4470-8bdf-cf43833e216f")),
                    new ModelOrder.Order(Guid.NewGuid(), 250, new Guid("d131e104-6ddc-4470-8bdf-cf43833e216f")),
                    new ModelOrder.Order(Guid.NewGuid(), 250, new Guid("d131e104-6ddc-4470-8bdf-cf43833e216f")),
                    new ModelOrder.Order(Guid.NewGuid(), 23, new Guid("d131e104-6ddc-4470-8bdf-cf43833e216f"))
                );
        }
    }
}
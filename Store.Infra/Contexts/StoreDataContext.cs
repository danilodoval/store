using Store.Domain.Entities;
using Store.Infra.Mappings;
using System.Data.Entity;

namespace Store.Infra.Contexts
{
    public class StoreDataContext : DbContext
    {
        public StoreDataContext() : base("StoreConnectionString")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new OrdemItemMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new ProdutMap());
            modelBuilder.Configurations.Add(new UserMap());
        }

    }
}

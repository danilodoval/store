using Store.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Store.Infra.Mappings
{
    public class ProdutMap : EntityTypeConfiguration<Product>
    {
        public ProdutMap()
        {
            ToTable("Product");
            HasKey(x => x.Id);
            Property(x => x.Image).IsRequired().HasMaxLength(1024);
            Property(x => x.Price);
            Property(x => x.QuantityOnHand);
            Property(x => x.Title).IsRequired().HasMaxLength(80);
        }
    }
}

using Store.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Store.Infra.Mappings
{
    public class OrdemItemMap : EntityTypeConfiguration<OrderItem>
    {
        public OrdemItemMap()
        {
            ToTable("OrderItem");
            HasKey(x => x.Id);
            Property(x => x.Price).HasColumnType("money");
            Property(x => x.Quantity);
            HasRequired(x => x.Product);
        }
    }
}

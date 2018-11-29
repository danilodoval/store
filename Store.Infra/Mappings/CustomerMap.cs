using Store.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Store.Infra.Mappings
{
    class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            ToTable("Customer");
            HasKey(x => x.Id);
            Property(x => x.BirthDate);
            Property(x => x.Document.Number).IsRequired().HasMaxLength(11).IsFixedLength();
            Property(x => x.Email.Address).IsRequired().HasMaxLength(160).HasColumnName("Email");
            Property(x => x.Name.FirstName).IsRequired().HasMaxLength(60);
            Property(x => x.Name.LastName).IsRequired().HasMaxLength(60);
            HasRequired(x => x.User);
        }
    }
}

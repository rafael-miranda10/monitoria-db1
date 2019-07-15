using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monitoria.Domain.Registration.Entities;
using Monitoria.Domain.Shared.ValueObjects;

namespace Monitoria.Infra.Data.Configurations.RegistrationContext
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");

            builder.HasKey(x => x.Id);

            //Mapeando objetos de valor
            builder.OwnsOne<Name>(x => x.Name, cb => {
                cb.Property(x => x.FirstName).HasMaxLength(50).HasColumnName("FirstName").IsRequired();
                cb.Property(x => x.LastName).HasMaxLength(50).HasColumnName("LastName").IsRequired();
            });

            builder.OwnsOne<Document>(x => x.Document, cb => {
                cb.Property(x => x.Number).HasMaxLength(50).HasColumnName("DocNumber").IsRequired();
                cb.Property(x => x.Type).HasColumnName("DocType").IsRequired();
            });

            builder.OwnsOne<Email>(x => x.Email, cb => {
                cb.Property(x => x.Address).HasMaxLength(60).HasColumnName("EmailAddress").IsRequired();
            });

            builder.OwnsOne<Address>(x => x.Address, cb => {
                cb.Property(x => x.Street).HasMaxLength(50).HasColumnName("AddressStreet").IsRequired();
                cb.Property(x => x.Number).HasColumnName("AddressNumber").IsRequired();
                cb.Property(x => x.Neighborhood).HasMaxLength(50).HasColumnName("AddressNeighborhood").IsRequired();
                cb.Property(x => x.City).HasMaxLength(50).HasColumnName("AddressCity").IsRequired();
                cb.Property(x => x.State).HasMaxLength(50).HasColumnName("AddressState").IsRequired();
                cb.Property(x => x.Country).HasMaxLength(50).HasColumnName("AddressCountry").IsRequired();
                cb.Property(x => x.ZipCode).HasMaxLength(8).HasColumnName("AddressZipCode").IsRequired();
            });

            //Relacionamento
            builder.HasMany(x => x.Animails)
                .WithOne(c => c.Customer)
                .HasForeignKey(k => k.CustomerId)
                .HasPrincipalKey(p => p.Id);
        }
    }
}

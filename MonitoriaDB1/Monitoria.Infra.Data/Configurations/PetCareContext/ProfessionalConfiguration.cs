using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.Shared.ValueObjects;

namespace Monitoria.Infra.Data.Configurations.PetCareContext
{
    public class ProfessionalConfiguration : IEntityTypeConfiguration<Professional>
    {
        public void Configure(EntityTypeBuilder<Professional> builder)
        {
            builder.ToTable("Professional");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.JobPosition)
              .IsRequired()
              .HasColumnName("JobPosition");

            //Mapeando objetos de valor
            builder.OwnsOne<Name>(x => x.Name, cb => {
                cb.Property(x => x.FirstName).HasMaxLength(50).HasColumnName("FirstName").IsRequired();
                cb.Property(x => x.LastName).HasMaxLength(50).HasColumnName("LastName").IsRequired();
                cb.ToTable("Professional");
            });

            builder.OwnsOne<Document>(x => x.Document, cb => {
                cb.Property(x => x.Number).HasMaxLength(50).HasColumnName("DocNumber").IsRequired();
                cb.Property(x => x.Type).HasColumnName("DocType").IsRequired();
                cb.ToTable("Professional");
            });

            builder.OwnsOne<Email>(x => x.Email, cb => {
                cb.Property(x => x.Address).HasMaxLength(60).HasColumnName("EmailAddress").IsRequired();
                cb.ToTable("Professional");
            });

            builder.OwnsOne<Address>(x => x.Address, cb => {
                cb.Property(x => x.Street).HasMaxLength(50).HasColumnName("AddressStreet").IsRequired();
                cb.Property(x => x.Number).HasColumnName("AddressNumber").IsRequired();
                cb.Property(x => x.Neighborhood).HasMaxLength(50).HasColumnName("AddressNeighborhood").IsRequired();
                cb.Property(x => x.City).HasMaxLength(50).HasColumnName("AddressCity").IsRequired();
                cb.Property(x => x.State).HasMaxLength(50).HasColumnName("AddressState").IsRequired();
                cb.Property(x => x.Country).HasMaxLength(50).HasColumnName("AddressCountry").IsRequired();
                cb.Property(x => x.ZipCode).HasMaxLength(8).HasColumnName("AddressZipCode").IsRequired();
                cb.ToTable("Professional");
            });

            //Relacionamento
            builder.HasMany(x => x.AnimailServices)
                .WithOne(c => c.Professional)
                .HasForeignKey(k => k.professionalId)
                .HasPrincipalKey(p => p.Id);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monitoria.Domain.PetCare.Entities;

namespace Monitoria.Infra.Data.Configurations.PetCareContext
{
    public class PetServicesConfiguration : IEntityTypeConfiguration<PetServices>
    {
        public void Configure(EntityTypeBuilder<PetServices> builder)
        {
            builder.ToTable("PetServices");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnName("Description")
                .HasMaxLength(50);

            builder.Property(x => x.CheckList)
               .IsRequired()
               .HasColumnName("CheckList")
               .HasMaxLength(200);

            builder.Property(x => x.ServiceValue)
              .IsRequired()
              .HasColumnName("ServiceValue")
              .HasColumnType("decimal(5,2)");

            builder.Property(x => x.Active)
              .IsRequired()
              .HasColumnName("Active");

            builder.Property(x => x.Category)
              .IsRequired()
              .HasColumnName("Category");


            //Relacionamento
            builder.HasMany(x => x.AnimailServices)
                .WithOne(c => c.PetService)
                .HasForeignKey(k => k.PetServiceId)
                .HasPrincipalKey(p => p.Id);
        }
    }
}

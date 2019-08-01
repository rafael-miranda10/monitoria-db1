using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monitoria.Infra.RepoModels.PetCare.Models;

namespace Monitoria.Infra.Data.Configurations.PetCareContext
{
    public class ProfessionalServicesAnimalConfiguration : IEntityTypeConfiguration<ProfessionalServicesAnimalRepModel>
    {
        public void Configure(EntityTypeBuilder<ProfessionalServicesAnimalRepModel> builder)
        {
            builder.ToTable("ProfessionalServicesAnimal");

            // builder.HasKey(x => x.Id);
            builder.HasKey(x => new { x.Id, x.PetServiceId, x.professionalId});

            builder.Property(x => x.Note)
                .IsRequired()
                .HasColumnName("Note")
                .HasMaxLength(150);

            builder.Property(x => x.EndDate).HasDefaultValue();

            builder.Property(x => x.StartDate)
               .IsRequired()
               .HasColumnName("StartDate");

            //Relacionamento RowAnimalCare
            builder.HasOne(x => x.RowAnimalCare)
                .WithMany(c => c.AnimailServices)
                .HasForeignKey(k => k.RowAnimalCareId)
                .HasPrincipalKey(p => p.Id);

        }
    }
}

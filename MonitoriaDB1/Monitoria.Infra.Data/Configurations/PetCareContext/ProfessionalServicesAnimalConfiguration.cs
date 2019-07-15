using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monitoria.Domain.PetCare.Entities;

namespace Monitoria.Infra.Data.Configurations.PetCareContext
{
    public class ProfessionalServicesAnimalConfiguration : IEntityTypeConfiguration<ProfessionalServicesAnimal>
    {
        public void Configure(EntityTypeBuilder<ProfessionalServicesAnimal> builder)
        {
            builder.ToTable("ProfessionalServicesAnimal");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Note)
                .IsRequired()
                .HasColumnName("Note")
                .HasMaxLength(150);

            builder.Property(x => x.StartDate)
               .IsRequired()
               .HasColumnName("StartDate");


        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monitoria.Infra.RepoModels.PetCare.Models;

namespace Monitoria.Infra.Data.Configurations.PetCareContext
{
    public class RowAnimalCareConfiguration : IEntityTypeConfiguration<RowAnimalCareRepModel>
    {
        public void Configure(EntityTypeBuilder<RowAnimalCareRepModel> builder)
        {
            builder.ToTable("RowAnimalCare");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ValueTotal)
                .IsRequired()
                .HasColumnName("ValueTotal")
                .HasColumnType("decimal(5,2)");

            //Relacionamento ProfessionalServicesAnimal
            builder.HasMany(x => x.AnimailServices)
                .WithOne(c => c.RowAnimalCare)
                .HasForeignKey(k => k.RowAnimalCareId)
                .HasPrincipalKey(p => p.Id);

            //Relacionamento AnimalPetCare
            builder.HasOne(x => x.AnimalPetCare)
                .WithOne(c => c.RowAnimalCare)
                .HasForeignKey<AnimalPetCareRepModel>(k => k.Id)
                .HasPrincipalKey<RowAnimalCareRepModel>(p => p.Id);
        }
    }
}

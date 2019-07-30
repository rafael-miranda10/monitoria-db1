using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monitoria.Domain.Registration.Entities;
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
            //builder.HasOne(x => x.Animal)
            //    .WithOne(c => c.RowAnimalCare)
            //    .HasForeignKey<Animal>(k => k.Id)
            //    .HasPrincipalKey<RowAnimalCareRepModel>(p => p.Id);
        }
    }
}

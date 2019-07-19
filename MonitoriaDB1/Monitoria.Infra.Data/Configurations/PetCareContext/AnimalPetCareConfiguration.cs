using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monitoria.Infra.RepoModels.PetCare.Models;

namespace Monitoria.Infra.Data.Configurations.PetCareContext
{
    public class AnimalPetCareConfiguration : IEntityTypeConfiguration<AnimalPetCareRepModel>
    {
        public void Configure(EntityTypeBuilder<AnimalPetCareRepModel> builder)
        {
            builder.ToTable("AnimalPetCare");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasMaxLength(40);

            builder.Property(x => x.Age)
               .IsRequired()
               .HasColumnName("Age");

            builder.Property(x => x.Specie)
              .IsRequired()
              .HasColumnName("Specie");

            //Relacionamento
            builder.HasOne(r => r.RowAnimalCare)
                .WithOne(c => c.AnimalPetCare)
                .HasForeignKey<RowAnimalCareRepModel>(k => k.Id)
                .HasPrincipalKey<AnimalPetCareRepModel > (p => p.Id);


        }
    }
}

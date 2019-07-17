using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monitoria.Infra.RepoModels.Registration.Models;

namespace Monitoria.Infra.Data.Configurations.RegistrationContext
{
    public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.ToTable("Animal");

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

            builder.Property(x => x.IsAlive)
              .IsRequired()
              .HasColumnName("IsAlive");

            //Relacionamento
            builder.HasOne(x => x.Customer)
                .WithMany(c => c.Animails)
                .HasForeignKey(k => k.CustomerId)
                .HasPrincipalKey(p => p.Id);

        }
    }
}

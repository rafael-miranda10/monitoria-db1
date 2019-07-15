﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Monitoria.Domain.PetCare.Entities;

namespace Monitoria.Infra.Data.Configurations.PetCareContext
{
    public class RowAnimalCareConfiguration : IEntityTypeConfiguration<RowAnimalCare>
    {
        public void Configure(EntityTypeBuilder<RowAnimalCare> builder)
        {
            builder.ToTable("RowAnimalCare");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ValueTotal)
                .IsRequired()
                .HasColumnName("ValueTotal");

            //Relacionamento ProfessionalServicesAnimal
            builder.HasMany(x => x.AnimailServices)
                .WithOne(c => c.RowAnimalCare)
                .HasForeignKey(k => k.RowAnimalCareId)
                .HasPrincipalKey(p => p.Id);

            //Relacionamento AnimalPetCare
            builder.HasOne(x => x.AnimalPetCare)
                .WithOne(c => c.RowAnimalCare)
                .HasForeignKey<AnimalPetCare>(k => k.Id)
                .HasPrincipalKey<RowAnimalCare>(p => p.Id);
        }
    }
}
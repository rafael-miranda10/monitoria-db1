using Microsoft.EntityFrameworkCore;
using Monitoria.Domain.PetCare.Entities;
using Monitoria.Infra.Data.Configurations.PetCareContext;

namespace Monitoria.Infra.Data.Contexts
{
    public class PetCareContext: DbContext
    {
        public PetCareContext(DbContextOptions<PetCareContext> options) : base(options)
        {

        }

        public DbSet<AnimalPetCare> AnimalPetCare { get; set; }
        public DbSet<PetServices> PetServices { get; set; }
        public DbSet<Professional> Professional { get; set; }
        public DbSet<ProfessionalServicesAnimal> ProfessionalServicesAnimal { get; set; }
        public DbSet<RowAnimalCare> RowAnimalCare { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("PetCare");

            modelBuilder.ApplyConfiguration(new AnimalPetCareConfiguration());
            modelBuilder.ApplyConfiguration(new PetServicesConfiguration());
            modelBuilder.ApplyConfiguration(new ProfessionalConfiguration());
            modelBuilder.ApplyConfiguration(new ProfessionalServicesAnimalConfiguration());
            modelBuilder.ApplyConfiguration(new RowAnimalCareConfiguration());

        }
    }
}

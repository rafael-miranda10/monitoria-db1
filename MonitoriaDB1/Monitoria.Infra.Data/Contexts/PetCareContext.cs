using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using Monitoria.Infra.Data.Configurations.PetCareContext;
using Monitoria.Infra.RepModels.Shared.ValueObjects;
using Monitoria.Infra.RepoModels.PetCare.Models;

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

            modelBuilder.Ignore<Address>();
            modelBuilder.Ignore<Document>();
            modelBuilder.Ignore<Email>();
            modelBuilder.Ignore<Name>();
            modelBuilder.Ignore<Notification>();

            modelBuilder.ApplyConfiguration(new AnimalPetCareConfiguration());
            modelBuilder.ApplyConfiguration(new PetServicesConfiguration());
            modelBuilder.ApplyConfiguration(new ProfessionalConfiguration());
            modelBuilder.ApplyConfiguration(new ProfessionalServicesAnimalConfiguration());
            modelBuilder.ApplyConfiguration(new RowAnimalCareConfiguration());

        }
    }
}

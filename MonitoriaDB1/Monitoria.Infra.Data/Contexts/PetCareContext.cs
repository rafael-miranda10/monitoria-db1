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

        public DbSet<AnimalPetCareRepModel> AnimalPetCare { get; set; }
        public DbSet<PetServicesRepModel> PetServices { get; set; }
        public DbSet<ProfessionalRepModel> Professional { get; set; }
        public DbSet<ProfessionalServicesAnimalRepModel> ProfessionalServicesAnimal { get; set; }
        public DbSet<RowAnimalCareRepModel> RowAnimalCare { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("PetCare");

            modelBuilder.Ignore<AddressRepModel>();
            modelBuilder.Ignore<DocumentRepModel>();
            modelBuilder.Ignore<EmailRepModel>();
            modelBuilder.Ignore<NameRepModel>();
            modelBuilder.Ignore<Notification>();

            modelBuilder.ApplyConfiguration(new AnimalPetCareConfiguration());
            modelBuilder.ApplyConfiguration(new PetServicesConfiguration());
            modelBuilder.ApplyConfiguration(new ProfessionalConfiguration());
            modelBuilder.ApplyConfiguration(new ProfessionalServicesAnimalConfiguration());
            modelBuilder.ApplyConfiguration(new RowAnimalCareConfiguration());

        }
    }
}

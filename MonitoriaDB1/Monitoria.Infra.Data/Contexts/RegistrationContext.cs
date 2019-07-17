using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using Monitoria.Infra.Data.Configurations.RegistrationContext;
using Monitoria.Infra.RepModels.Shared.ValueObjects;
using Monitoria.Infra.RepoModels.Registration.Models;

namespace Monitoria.Infra.Data.Contexts
{
    public class RegistrationContext : DbContext
    {
        public RegistrationContext(DbContextOptions<RegistrationContext> options) : base(options)
        {

        }


        public DbSet<Animal> Animal { get; set; }
        public DbSet<Customer> Customer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("Registration");

            modelBuilder.Ignore<Address>();
            modelBuilder.Ignore<Document>();
            modelBuilder.Ignore<Email>();
            modelBuilder.Ignore<Name>();
            modelBuilder.Ignore<Notification>();

            modelBuilder.ApplyConfiguration(new AnimalConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());

        }

    }
}

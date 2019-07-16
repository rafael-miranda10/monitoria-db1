using Microsoft.EntityFrameworkCore;
using Monitoria.Domain.Registration.Entities;
using Monitoria.Domain.Shared.ValueObjects;
using Monitoria.Infra.Data.Configurations.RegistrationContext;

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

            modelBuilder.ApplyConfiguration(new AnimalConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());

        }

    }
}

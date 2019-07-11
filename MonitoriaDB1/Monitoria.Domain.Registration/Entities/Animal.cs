using Flunt.Validations;
using Monitoria.Domain.Registration.Enum;
using Monitoria.Infra.Shared.Entities;

namespace Monitoria.Domain.Registration.Entities
{
    public class Animal : Entity
    {

        public Animal(string name, int age, SpeciesEnum specie, bool isAlive)
        {
            Name = name;
            Age = age;
            Specie = specie;
            IsAlive = isAlive;

            AddNotifications(new Contract()
                .Requires()
                .IsLowerThan(0,Age,"Animal.Age", "A idade deve ser maior que zero")
                .HasMinLen(Name, 3, "Animal.Name", "O nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(Name, 40, "Animal.Name", "Nome deve conter até 40 caracteres")
                );
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public SpeciesEnum Specie { get; private set; }
        public bool IsAlive { get; private set; }
    }
}

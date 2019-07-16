using Flunt.Validations;
using Monitoria.Domain.Shared.Entities;
using Monitoria.Domain.Shared.Enum;
using System;

namespace Monitoria.Domain.Registration.Entities
{
    public class Animal : Entity
    {
        public Animal()
        {

        }
        public Animal(string name, int age, SpeciesEnum specie, bool isAlive)
        {
            Name = name;
            Age = age;
            Specie = specie;
            IsAlive = isAlive;

            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(Age, 0, "Animal.Age", "A idade do animal deve ser maior que zero")
                .HasMinLen(Name, 3, "Animal.Name", "O nome do animal deve conter pelo menos 3 caracteres")
                .HasMaxLen(Name, 40, "Animal.Name", "Nome do animal deve conter até 40 caracteres")
                );
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public SpeciesEnum Specie { get; private set; }
        public bool IsAlive { get; private set; }
        public Guid CustomerId { get; private set; }
        public virtual Customer Customer {get; private set;}
    }
}

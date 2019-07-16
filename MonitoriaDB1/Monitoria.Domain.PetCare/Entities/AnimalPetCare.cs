using Flunt.Validations;
using Monitoria.Domain.Shared.Entities;
using Monitoria.Domain.Shared.Enum;
using System;

namespace Monitoria.Domain.PetCare.Entities
{
    public class AnimalPetCare : Entity
    {
        public AnimalPetCare()
        {

        }

        public AnimalPetCare(string name, int age, SpeciesEnum specie)
        {
            Name = name;
            Age = age;
            Specie = specie;

            AddNotifications(new Contract()
                .Requires()
                .IsLowerThan(0, Age, "Animal.Age", "A idade deve ser maior que zero")
                .HasMinLen(Name, 3, "Animal.Name", "O nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(Name, 40, "Animal.Name", "Nome deve conter até 40 caracteres")
                );
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public SpeciesEnum Specie { get; private set; }
        public RowAnimalCare RowAnimalCare { get; private set; }
    }
}

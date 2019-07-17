using Monitoria.Infra.RepModels.Shared.Entity;
using Monitoria.Infra.RepModels.Shared.Enum;

namespace Monitoria.Infra.RepoModels.PetCare.Models
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
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public SpeciesEnum Specie { get; private set; }
        public RowAnimalCare RowAnimalCare { get; private set; }
    }
}

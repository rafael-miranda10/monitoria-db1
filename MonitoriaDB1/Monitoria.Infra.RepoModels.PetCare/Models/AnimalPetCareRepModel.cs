using Monitoria.Infra.RepModels.Shared.Entity;
using Monitoria.Infra.RepModels.Shared.Enum;

namespace Monitoria.Infra.RepoModels.PetCare.Models
{
    public class AnimalPetCareRepModel : Entity
    {
        public AnimalPetCareRepModel()
        {
        }
        public AnimalPetCareRepModel(string name, int age, SpeciesEnum specie)
        {
            Name = name;
            Age = age;
            Specie = specie;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public SpeciesEnum Specie { get; private set; }
        public RowAnimalCareRepModel RowAnimalCare { get; private set; }
    }
}

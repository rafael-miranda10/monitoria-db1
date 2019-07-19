using Monitoria.Infra.RepModels.Shared.Entity;
using Monitoria.Infra.RepModels.Shared.Enum;
using System;

namespace Monitoria.Infra.RepoModels.PetCare.Models
{
    public class AnimalPetCareRepModel : Entity
    {
        public AnimalPetCareRepModel(string name, int age, SpeciesEnum specie)
        {
            Name = name;
            Age = age;
            Specie = specie;
            RowAnimalCare = new RowAnimalCareRepModel();
        }
        public AnimalPetCareRepModel(Guid customerId, string name, int age, SpeciesEnum specie)
        {
            Name = name;
            Age = age;
            Specie = specie;
            CustomerId = customerId;
            RowAnimalCare = new RowAnimalCareRepModel();
        }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public SpeciesEnum Specie { get; private set; }
        public RowAnimalCareRepModel RowAnimalCare { get; private set; }
        public Guid CustomerId { get; set; }
    }
}

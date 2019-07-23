using Monitoria.API.ViewModels.Shared;

namespace Monitoria.API.ViewModels.PetCare
{
    public class AnimalPetCareViewModel : Entity
    {
        public AnimalPetCareViewModel()
        {

        }
        public AnimalPetCareViewModel(string name, int age, int specie)
        {
            Name = name;
            Age = age;
            Specie = specie;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public int Specie { get; set; }
        public RowAnimalCareViewModel RowAnimalCare { get; set; }
    }
}

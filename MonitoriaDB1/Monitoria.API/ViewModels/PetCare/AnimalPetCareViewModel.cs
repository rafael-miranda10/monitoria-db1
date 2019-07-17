namespace Monitoria.API.ViewModels.PetCare
{
    public class AnimalPetCareViewModel
    {
        public AnimalPetCareViewModel(string name, int age, int specie)
        {
            Name = name;
            Age = age;
            Specie = specie;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public int Specie { get; private set; }
        public RowAnimalCareViewModel RowAnimalCare { get; private set; }
    }
}

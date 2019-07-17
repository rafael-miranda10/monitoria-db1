namespace Monitoria.API.ViewModels.Registration
{
    public class AnimalViewModel
    {
        public AnimalViewModel(string name, int age, int specie, bool isAlive)
        {
            Name = name;
            Age = age;
            Specie = specie;
            IsAlive = isAlive;
        }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public int Specie { get; private set; }
        public bool IsAlive { get; private set; }
        public CustomerViewModel Customer { get; private set; }
    }
}

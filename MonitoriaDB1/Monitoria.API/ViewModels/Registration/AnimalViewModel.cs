using Flunt.Notifications;
using Newtonsoft.Json;

namespace Monitoria.API.ViewModels.Registration
{
    public class AnimalViewModel : Notifiable
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
        [JsonIgnore]
        public CustomerViewModel Customer { get; private set; }
    }
}

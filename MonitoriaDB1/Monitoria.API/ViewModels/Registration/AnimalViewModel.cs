using Monitoria.API.ViewModels.Shared;
using Newtonsoft.Json;
using System;

namespace Monitoria.API.ViewModels.Registration
{
    public class AnimalViewModel : Entity
    {
        public AnimalViewModel(string name, int age, int specie, bool isAlive)
        {
            Name = name;
            Age = age;
            Specie = specie;
            IsAlive = isAlive;           
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Specie { get; set; }
        public bool IsAlive { get; set; }
        [JsonIgnore]
        public CustomerViewModel Customer { get; set; }
    }
}

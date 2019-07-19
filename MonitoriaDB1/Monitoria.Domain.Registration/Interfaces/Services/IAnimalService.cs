using Monitoria.Domain.Registration.Entities;
using System.Collections.Generic;

namespace Monitoria.Domain.Registration.Interfaces.Services
{
    public interface IAnimalService 
    {
        IEnumerable<Animal> GetByAnimalName(string name);
    }
}

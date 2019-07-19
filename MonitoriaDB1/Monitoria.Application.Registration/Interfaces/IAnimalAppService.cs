using Monitoria.Domain.Registration.Entities;
using System.Collections.Generic;

namespace Monitoria.Application.Registration.Interfaces
{
    public interface IAnimalAppService 
    {
        IEnumerable<Animal> GetByAnimalName(string name);
    }
}

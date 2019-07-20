using Monitoria.Domain.Registration.Entities;
using System;
using System.Collections.Generic;

namespace Monitoria.Application.Registration.Interfaces
{
    public interface IAnimalAppService 
    {
        IEnumerable<Animal> GetByAnimalName(string name);
        IEnumerable<Animal> GetByCustomerId(Guid customerId);
        IEnumerable<Animal> GetAllAnimal();
        Animal GetAnimalById(Guid id);

    }
}

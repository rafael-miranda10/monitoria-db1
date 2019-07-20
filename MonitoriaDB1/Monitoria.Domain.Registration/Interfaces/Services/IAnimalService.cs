using Monitoria.Domain.Registration.Entities;
using System;
using System.Collections.Generic;

namespace Monitoria.Domain.Registration.Interfaces.Services
{
    public interface IAnimalService 
    {
        IEnumerable<Animal> GetByAnimalName(string name);
        IEnumerable<Animal> GetByCustomerId(Guid customerId);
        IEnumerable<Animal> GetAllAnimal();
        Animal GetAnimalById(Guid id);
    }
}

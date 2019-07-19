using Monitoria.Domain.Registration.Entities;
using System;
using System.Collections.Generic;

namespace Monitoria.Domain.Registration.Interfaces.Repositories
{
    public interface IAnimalRepository 
    {
        IEnumerable<Animal> GetByAnimalName(string name);
        IEnumerable<Animal> GetByCustomerId(Guid customerId);
        IEnumerable<Animal> GetAll();
        Animal GetById(Guid id);
    }
}

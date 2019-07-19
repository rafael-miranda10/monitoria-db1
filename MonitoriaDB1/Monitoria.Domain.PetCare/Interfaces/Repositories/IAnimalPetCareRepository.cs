using Monitoria.Domain.PetCare.Entities;
using System;
using System.Collections.Generic;

namespace Monitoria.Domain.PetCare.Interfaces.Repositories
{
    public interface IAnimalPetCareRepository 
    {
        IEnumerable<AnimalPetCare> GetByAnimalPetCareName(string Name);
        IEnumerable<AnimalPetCare> GetByCustomerId(Guid customerId);
        IEnumerable<AnimalPetCare> GetAllAnimal();
        AnimalPetCare GetAnimalPetCareById(Guid id);
    }
}

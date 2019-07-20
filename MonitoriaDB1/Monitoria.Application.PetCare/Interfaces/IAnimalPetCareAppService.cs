using Monitoria.Domain.PetCare.Entities;
using System;
using System.Collections.Generic;

namespace Monitoria.Application.PetCare.Interfaces
{
    public interface IAnimalPetCareAppService 
    {
        IEnumerable<AnimalPetCare> GetByAnimalPetCareName(string Name);
        IEnumerable<AnimalPetCare> GetByCustomerId(Guid customerId);
        IEnumerable<AnimalPetCare> GetAllAnimal();
        AnimalPetCare GetAnimalPetCareById(Guid id);
    }
}

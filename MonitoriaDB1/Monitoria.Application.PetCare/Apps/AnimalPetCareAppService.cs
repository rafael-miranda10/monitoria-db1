using Monitoria.Application.PetCare.Interfaces;
using Monitoria.Application.Shared.Apps;
using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.PetCare.Interfaces.Services;
using System.Collections.Generic;

namespace Monitoria.Application.PetCare.Apps
{
    public class AnimalPetCareAppService :  IAnimalPetCareAppService
    {
        private readonly IAnimalPetCareService _animalPetCareService;

        public AnimalPetCareAppService(IAnimalPetCareService animalPetCareService) 
        {
            _animalPetCareService = animalPetCareService;
        }

        public IEnumerable<AnimalPetCare> GetByAnimalPetCareName(string Name)
        {
            return _animalPetCareService.GetByAnimalPetCareName(Name);
        }
    }
}

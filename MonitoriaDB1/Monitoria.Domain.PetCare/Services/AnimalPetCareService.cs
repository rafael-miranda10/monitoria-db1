using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.PetCare.Interfaces.Repositories;
using Monitoria.Domain.PetCare.Interfaces.Services;
using Monitoria.Domain.Shared.Services;
using System.Collections.Generic;

namespace Monitoria.Domain.PetCare.Services
{
    public class AnimalPetCareService : ServiceBase<AnimalPetCare>, IAnimalPetCareService
    {
        private readonly IAnimalPetCareRepository _animalPetCareRepository;

        public AnimalPetCareService(IAnimalPetCareRepository animalPetCareRepository) : base(animalPetCareRepository)
        {
            _animalPetCareRepository = animalPetCareRepository;
        }

        public IEnumerable<AnimalPetCare> GetByAnimalPetCareName(string Name)
        {
            return _animalPetCareRepository.GetByAnimalPetCareName(Name);
        }
    }
}

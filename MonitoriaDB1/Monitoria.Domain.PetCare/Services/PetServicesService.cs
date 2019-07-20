using System;
using System.Collections.Generic;
using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.PetCare.Interfaces.Repositories;
using Monitoria.Domain.PetCare.Interfaces.Services;

namespace Monitoria.Domain.PetCare.Services
{
    public class PetServicesService:  IPetServicesService
    {
        private readonly IPetServicesRepository _petServicesRepository; 

        public PetServicesService(IPetServicesRepository petServicesRepository) 
        {
            _petServicesRepository = petServicesRepository;
        }

        public void AddPetServices(PetServices petServices)
        {
            _petServicesRepository.AddPetServices(petServices);
        }

        public bool ExistingEntity(PetServices petServices)
        {
            return _petServicesRepository.ExistingEntity(petServices);
        }

        public IEnumerable<PetServices> GetAllPetServices()
        {
            return _petServicesRepository.GetAllPetServices();
        }

        public IEnumerable<PetServices> GetByPetServicesDescription(string description)
        {
            return _petServicesRepository.GetByPetServicesDescription(description);
        }

        public PetServices GetEntityEqualTo(PetServices petServices)
        {
            return _petServicesRepository.GetEntityEqualTo(petServices);
        }

        public PetServices GetPetServicesById(Guid id)
        {
            return _petServicesRepository.GetPetServicesById(id);
        }

        public void RemovePetServices(PetServices petServices)
        {
            _petServicesRepository.RemovePetServices(petServices);
        }

        public void RemovePetServicesById(Guid id)
        {
            _petServicesRepository.RemovePetServicesById(id);
        }

        public void UpdatePetServices(PetServices petServices)
        {
            _petServicesRepository.UpdatePetServices(petServices);
        }
    }
}

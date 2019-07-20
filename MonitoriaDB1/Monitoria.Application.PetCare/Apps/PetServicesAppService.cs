using System;
using System.Collections.Generic;
using Monitoria.Application.PetCare.Interfaces;
using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.PetCare.Interfaces.Services;

namespace Monitoria.Application.PetCare.Apps
{
    public class PetServicesAppService :  IPetServicesAppService
    {
        private readonly IPetServicesService _petServicesService;

        public PetServicesAppService(IPetServicesService petServicesService) 
        {
            _petServicesService = petServicesService;
        }

        public void AddPetServices(PetServices petServices)
        {
            _petServicesService.AddPetServices(petServices);
        }

        public bool ExistingEntity(PetServices petServices)
        {
            return _petServicesService.ExistingEntity(petServices);
        }

        public IEnumerable<PetServices> GetAllPetServices()
        {
            return _petServicesService.GetAllPetServices();
        }

        public IEnumerable<PetServices> GetByPetServicesDescription(string description)
        {
            return _petServicesService.GetByPetServicesDescription(description);
        }

        public PetServices GetEntityEqualTo(PetServices petServices)
        {
            return _petServicesService.GetEntityEqualTo(petServices);
        }

        public PetServices GetPetServicesById(Guid id)
        {
            return _petServicesService.GetPetServicesById(id);
        }

        public void RemovePetServices(PetServices petServices)
        {
            _petServicesService.RemovePetServices(petServices);
        }

        public void RemovePetServicesById(Guid id)
        {
            _petServicesService.RemovePetServicesById(id);
        }

        public void UpdatePetServices(PetServices petServices)
        {
            _petServicesService.UpdatePetServices(petServices);
        }
    }
}

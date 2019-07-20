using Monitoria.Domain.PetCare.Entities;
using System;
using System.Collections.Generic;

namespace Monitoria.Application.PetCare.Interfaces
{
    public interface IPetServicesAppService 
    {
        void AddPetServices(PetServices petServices);
        void UpdatePetServices(PetServices petServices);
        void RemovePetServices(PetServices petServices);
        void RemovePetServicesById(Guid id);
        IEnumerable<PetServices> GetAllPetServices();
        IEnumerable<PetServices> GetByPetServicesDescription(string description);
        PetServices GetPetServicesById(Guid id);
        PetServices GetEntityEqualTo(PetServices petServices);
        bool ExistingEntity(PetServices petServices);
    }
}

using Monitoria.Domain.PetCare.Entities;
using System;
using System.Collections.Generic;

namespace Monitoria.Domain.PetCare.Interfaces.Repositories
{
    public interface IPetServicesRepository
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

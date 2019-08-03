using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.Registration.Entities;
using System;
using System.Collections.Generic;

namespace Monitoria.Domain.PetCare.Interfaces.Services
{
    public interface IRowAnimalCareService 
    {
        void AddRowAnimalCare(RowAnimalCare rowAnimalCare);
        void UpdateRowAnimalCare(RowAnimalCare rowAnimalCare);
        void RemoveRowAnimalCare(RowAnimalCare rowAnimalCare);
        void RemoveRowAnimalCareById(Guid id);
        IEnumerable<RowAnimalCare> GetAllRowAnimalCare();
        IEnumerable<RowAnimalCare> GetAllServicesOfAnimal(Animal animal);
        RowAnimalCare GetRowAnimalCareById(Guid id);
        RowAnimalCare GetEntityEqualTo(RowAnimalCare rowAnimalCare);
        bool ExistingEntity(RowAnimalCare rowAnimalCare);
        void StartPetCareServiceOnRow(RowAnimalCare rowAnimalCare, Guid petCareServiceId);
        void EndPetCareServiceOnRow(RowAnimalCare rowAnimalCare, Guid petCareServiceId);
        void calculateValueTotalOnRow(RowAnimalCare rowAnimalCare);
    }
}

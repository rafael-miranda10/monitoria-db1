using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.Registration.Entities;
using System;
using System.Collections.Generic;

namespace Monitoria.Application.PetCare.Interfaces
{
    public interface IRowAnimalCareAppService 
    {
        RowAnimalCare AddRowAnimalCare(RowAnimalCare rowAnimalCare);
        void UpdateRowAnimalCare(RowAnimalCare rowAnimalCare);
        void RemoveRowAnimalCare(RowAnimalCare rowAnimalCare);
        void RemoveRowAnimalCareById(Guid id);
        IEnumerable<RowAnimalCare> GetAllRowAnimalCare();
        IEnumerable<RowAnimalCare> GetAllServicesOfAnimal(Animal animal);
        RowAnimalCare GetRowAnimalCareById(Guid id);
        RowAnimalCare GetEntityEqualTo(RowAnimalCare rowAnimalCare);
        bool ExistingEntity(RowAnimalCare rowAnimalCare);
        void StartPetCareServiceOnRow(Guid rowAnimalCareId, Guid petCareServiceId);
        ProfessionalServicesAnimal EndPetCareServiceOnRow(Guid rowAnimalCareId, Guid petCareServiceId);
        void calculateValueTotalOnRow(Guid rowAnimalCareId);
        RowAnimalCare AlterProfessionalService(Guid rowAnimalCareId, Guid petServiceId, Guid newProfessionalId);
        RowAnimalCare AddPetServiceOnRowAnimalCare(Guid rowAnimalCareId, ProfessionalServicesAnimal professionalServices);
    }
}

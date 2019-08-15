using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.Registration.Entities;
using System;
using System.Collections.Generic;

namespace Monitoria.Domain.PetCare.Interfaces.Services
{
    public interface IRowAnimalCareService 
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
        RowAnimalCare StartPetCareServiceOnRow(RowAnimalCare rowAnimalCare, Guid petCareServiceId);
        RowAnimalCare EndPetCareServiceOnRow(RowAnimalCare rowAnimalCare, Guid petCareServiceId);
        RowAnimalCare calculateValueTotalOnRow(RowAnimalCare rowAnimalCare);
        Professional GetProfessionalById(Guid Id);
        PetServices GetPetServiceById(Guid Id);
        RowAnimalCare AlterProfessionalService(Guid rowAnimalCareId, Guid petServiceId, Guid newProfessionalId);
        RowAnimalCare AddPetServiceOnRowAnimalCare(RowAnimalCare rowAnimalCare, ProfessionalServicesAnimal professionalServices);
    }
}

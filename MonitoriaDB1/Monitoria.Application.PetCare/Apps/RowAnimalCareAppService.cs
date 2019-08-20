using Monitoria.Application.PetCare.Interfaces;
using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.PetCare.Interfaces.Services;
using Monitoria.Domain.Registration.Entities;
using Monitoria.Domain.Registration.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Monitoria.Application.PetCare.Apps
{
    public class RowAnimalCareAppService : IRowAnimalCareAppService
    {
        private readonly IRowAnimalCareService _rowAnimalCareService;
        private readonly IAnimalService _animalService;

        public RowAnimalCareAppService(IRowAnimalCareService rowAnimalCareService, IAnimalService animalService)
        {
            _rowAnimalCareService = rowAnimalCareService;
            _animalService = animalService;
        }

        public RowAnimalCare AddRowAnimalCare(RowAnimalCare rowAnimalCare)
        {
            rowAnimalCare.AddAnimalToRow(_animalService.GetAnimalById(rowAnimalCare.Animal.Id));
            var result = _rowAnimalCareService.AddRowAnimalCare(rowAnimalCare);
            return result;
        }

        public bool ExistingEntity(RowAnimalCare rowAnimalCare)
        {
            return _rowAnimalCareService.ExistingEntity(rowAnimalCare);
        }

        public IEnumerable<RowAnimalCare> GetAllRowAnimalCare()
        {
            return _rowAnimalCareService.GetAllRowAnimalCare();
        }

        public IEnumerable<RowAnimalCare> GetAllServicesOfAnimal(Animal animal)
        {
            return _rowAnimalCareService.GetAllServicesOfAnimal(animal);
        }

        public RowAnimalCare GetEntityEqualTo(RowAnimalCare rowAnimalCare)
        {
            return _rowAnimalCareService.GetEntityEqualTo(rowAnimalCare);
        }

        public RowAnimalCare GetRowAnimalCareById(Guid id)
        {
            return _rowAnimalCareService.GetRowAnimalCareById(id);
        }

        public void RemoveRowAnimalCare(RowAnimalCare rowAnimalCare)
        {
            _rowAnimalCareService.RemoveRowAnimalCare(rowAnimalCare);
        }

        public void RemoveRowAnimalCareById(Guid id)
        {
            _rowAnimalCareService.RemoveRowAnimalCareById(id);
        }

        public void UpdateRowAnimalCare(RowAnimalCare rowAnimalCare)
        {
            _rowAnimalCareService.UpdateRowAnimalCare(rowAnimalCare);
        }

        IEnumerable<RowAnimalCare> IRowAnimalCareAppService.GetAllServicesOfAnimal(Animal animal)
        {
            return _rowAnimalCareService.GetAllServicesOfAnimal(animal);
        }

        public void StartPetCareServiceOnRow(Guid rowAnimalCareId, Guid petCareServiceId)
        {
            var RowAnimal = _rowAnimalCareService.GetRowAnimalCareById(rowAnimalCareId);
            _rowAnimalCareService.StartPetCareServiceOnRow(RowAnimal, petCareServiceId);
        }
        public ProfessionalServicesAnimal EndPetCareServiceOnRow(Guid rowAnimalCareId, Guid petCareServiceId)
        {
            var RowAnimal = _rowAnimalCareService.GetRowAnimalCareById(rowAnimalCareId);
            var petCare = _rowAnimalCareService.EndPetCareServiceOnRow(RowAnimal, petCareServiceId);
            return petCare;
        }
        public void calculateValueTotalOnRow(Guid rowAnimalCareId)
        {
             var RowAnimal = _rowAnimalCareService.GetRowAnimalCareById(rowAnimalCareId);
            _rowAnimalCareService.calculateValueTotalOnRow(RowAnimal);
        }

        public RowAnimalCare AlterProfessionalService(Guid rowAnimalCareId, Guid petServiceId, Guid newProfessionalId)
        {
           return _rowAnimalCareService.AlterProfessionalService(rowAnimalCareId, petServiceId, newProfessionalId);
        }

        public RowAnimalCare AddPetServiceOnRowAnimalCare(Guid rowAnimalCareId, ProfessionalServicesAnimal professionalServices)
        {
            var RowAnimal = _rowAnimalCareService.GetRowAnimalCareById(rowAnimalCareId);
            var rowResult = _rowAnimalCareService.AddPetServiceOnRowAnimalCare(RowAnimal, professionalServices);
            return rowResult;
        }
    }
}

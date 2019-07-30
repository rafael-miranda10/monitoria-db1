using Monitoria.Application.PetCare.Interfaces;
using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.PetCare.Interfaces.Services;
using Monitoria.Domain.Registration.Entities;
using System;
using System.Collections.Generic;

namespace Monitoria.Application.PetCare.Apps
{
    public class RowAnimalCareAppService : IRowAnimalCareAppService
    {
        private readonly IRowAnimalCareService _rowAnimalCareService;

        public RowAnimalCareAppService(IRowAnimalCareService rowAnimalCareService) 
        {
            _rowAnimalCareService = rowAnimalCareService;
        }

        public void AddRowAnimalCare(RowAnimalCare rowAnimalCare)
        {
            _rowAnimalCareService.AddRowAnimalCare(rowAnimalCare);
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
    }
}

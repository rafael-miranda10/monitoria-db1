using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.PetCare.Interfaces.Repositories;
using Monitoria.Domain.PetCare.Interfaces.Services;
using Monitoria.Domain.Registration.Entities;
using Monitoria.Domain.Shared.Services;
using System;
using System.Collections.Generic;

namespace Monitoria.Domain.PetCare.Services
{
    public class RowAnimalCareService : IRowAnimalCareService
    {
        private readonly IRowAnimalCareRepository _rowAnimalCareRepository;

        public RowAnimalCareService(IRowAnimalCareRepository rowAnimalCareRepository) 
        {
            _rowAnimalCareRepository = rowAnimalCareRepository;
        }

        public void AddRowAnimalCare(RowAnimalCare rowAnimalCare)
        {
            _rowAnimalCareRepository.AddRowAnimalCare(rowAnimalCare);
        }

        public bool ExistingEntity(RowAnimalCare rowAnimalCare)
        {
           return _rowAnimalCareRepository.ExistingEntity(rowAnimalCare);
        }

        public IEnumerable<RowAnimalCare> GetAllRowAnimalCare()
        {
            return _rowAnimalCareRepository.GetAllRowAnimalCare();
        }

        public IEnumerable<RowAnimalCare> GetAllServicesOfAnimal(Animal animal)
        {
            return _rowAnimalCareRepository.GetAllServicesOfAnimal(animal);
        }

        public RowAnimalCare GetEntityEqualTo(RowAnimalCare rowAnimalCare)
        {
            return _rowAnimalCareRepository.GetEntityEqualTo(rowAnimalCare);
        }

        public RowAnimalCare GetRowAnimalCareById(Guid id)
        {
            return _rowAnimalCareRepository.GetRowAnimalCareById(id);
        }

        public void RemoveRowAnimalCare(RowAnimalCare rowAnimalCare)
        {
            _rowAnimalCareRepository.RemoveRowAnimalCare(rowAnimalCare);
        }

        public void RemoveRowAnimalCareById(Guid id)
        {
            _rowAnimalCareRepository.RemoveRowAnimalCareById(id);
        }

        public void UpdateRowAnimalCare(RowAnimalCare rowAnimalCare)
        {
            _rowAnimalCareRepository.UpdateRowAnimalCare(rowAnimalCare);
        }

        IEnumerable<RowAnimalCare> IRowAnimalCareService.GetAllServicesOfAnimal(Animal animal)
        {
            return _rowAnimalCareRepository.GetAllServicesOfAnimal(animal);
        }
    }
}

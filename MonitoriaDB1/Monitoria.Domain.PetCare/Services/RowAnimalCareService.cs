using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.PetCare.Interfaces.Repositories;
using Monitoria.Domain.PetCare.Interfaces.Services;
using Monitoria.Domain.Registration.Entities;
using Monitoria.Domain.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Monitoria.Domain.PetCare.Services
{
    public class RowAnimalCareService : IRowAnimalCareService
    {
        private readonly IRowAnimalCareRepository _rowAnimalCareRepository;
        private readonly IPetServicesRepository _petServicesRepository;

        public RowAnimalCareService(IRowAnimalCareRepository rowAnimalCareRepository, IPetServicesRepository petServicesRepository) 
        {
            _rowAnimalCareRepository = rowAnimalCareRepository;
            _petServicesRepository = petServicesRepository;
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

        public void StartPetCareServiceOnRow(RowAnimalCare rowAnimalCare, Guid petCareServiceId)
        {
            var PetCareService = (from p in rowAnimalCare.AnimailServices
                                  where p.Id.Equals(petCareServiceId)
                                  select p).FirstOrDefault();

            PetCareService.StartThePetService();
            _rowAnimalCareRepository.UpdateRowAnimalCare(rowAnimalCare);
        }

        public void EndPetCareServiceOnRow(RowAnimalCare rowAnimalCare, Guid petCareServiceId)
        {
            var PetCareService = (from p in rowAnimalCare.AnimailServices
                                  where p.Id.Equals(petCareServiceId)
                                  select p).FirstOrDefault();

            PetCareService.FinalizeThePetService(DateTime.Now);
            _rowAnimalCareRepository.UpdateRowAnimalCare(rowAnimalCare);
        }
        public void calculateValueTotalOnRow(RowAnimalCare rowAnimalCare)
        {
            decimal total = 0;
            foreach(var item in rowAnimalCare.AnimailServices)
            {
                var petCareServie = _petServicesRepository.GetPetServicesById(item.PetService.Id);
                total += petCareServie.ServiceValue;
            }
            rowAnimalCare.CalculatePriceTotal(total);
            _rowAnimalCareRepository.UpdateRowAnimalCare(rowAnimalCare);
        }

        public Professional GetProfessionalById(Guid Id)
        {
            return _rowAnimalCareRepository.GetProfessionalById(Id);
        }

        public PetServices GetPetServiceById(Guid Id)
        {
            return _rowAnimalCareRepository.GetPetServiceById(Id);
        }

        public void AlterProfessionalService(Guid rowAnimalCareId, Guid petServiceId, Guid newProfessionalId)
        {
            var petService = _rowAnimalCareRepository.GetPetServiceById(petServiceId);
            var newProfessional = _rowAnimalCareRepository.GetProfessionalById(newProfessionalId);
            var rowAnimalCare = _rowAnimalCareRepository.GetRowAnimalCareById(rowAnimalCareId);
            var result = rowAnimalCare.AnimailServices.Where(x => x.PetService.Id.Equals(petServiceId)).FirstOrDefault();
            rowAnimalCare.AnimailServices.Remove(result);
            result.AlterProfessional(newProfessional);
            rowAnimalCare.AnimailServices.Add(result);
            _rowAnimalCareRepository.UpdateRowAnimalCare(rowAnimalCare);
        }
    }
}

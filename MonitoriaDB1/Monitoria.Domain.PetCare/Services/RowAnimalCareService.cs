using Flunt.Notifications;
using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.PetCare.Interfaces.Repositories;
using Monitoria.Domain.PetCare.Interfaces.Services;
using Monitoria.Domain.Registration.Entities;
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

        public RowAnimalCare AddRowAnimalCare(RowAnimalCare rowAnimalCare)
        {
            if (!rowAnimalCare.Notifications.Any())
                _rowAnimalCareRepository.AddRowAnimalCare(rowAnimalCare);

            return rowAnimalCare;
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

        public RowAnimalCare StartPetCareServiceOnRow(RowAnimalCare rowAnimalCare, Guid petCareServiceId)
        {
            var PetCareService = (from p in rowAnimalCare.AnimailServices
                                  where p.Id.Equals(petCareServiceId)
                                  select p).FirstOrDefault();

            if (PetCareService != null)
            {
                PetCareService.StartThePetService();
                _rowAnimalCareRepository.UpdateRowAnimalCare(rowAnimalCare);
                return rowAnimalCare;
            }
            return null;
        }

        public RowAnimalCare EndPetCareServiceOnRow(RowAnimalCare rowAnimalCare, Guid petCareServiceId)
        {
            var PetCareService = (from p in rowAnimalCare.AnimailServices
                                  where p.Id.Equals(petCareServiceId)
                                  select p).FirstOrDefault();

            PetCareService.FinalizeThePetService(DateTime.Now);
            _rowAnimalCareRepository.UpdateRowAnimalCare(rowAnimalCare);
            return rowAnimalCare;
        }
        public RowAnimalCare calculateValueTotalOnRow(RowAnimalCare rowAnimalCare)
        {
            decimal total = 0;
            foreach (var item in rowAnimalCare.AnimailServices)
            {
                var petCareServie = _petServicesRepository.GetPetServicesById(item.PetService.Id);
                total += petCareServie.ServiceValue;
            }
            rowAnimalCare.CalculatePriceTotal(total);
            _rowAnimalCareRepository.UpdateRowAnimalCare(rowAnimalCare);
            return rowAnimalCare;
        }

        public Professional GetProfessionalById(Guid Id)
        {
            return _rowAnimalCareRepository.GetProfessionalById(Id);
        }

        public PetServices GetPetServiceById(Guid Id)
        {
            return _rowAnimalCareRepository.GetPetServiceById(Id);
        }

        public RowAnimalCare AlterProfessionalService(Guid rowAnimalCareId, Guid petServiceId, Guid newProfessionalId)
        {
            var rowAnimalCare = _rowAnimalCareRepository.GetRowAnimalCareById(rowAnimalCareId);
            var result = rowAnimalCare.AnimailServices.Where(x => x.PetService.Id.Equals(petServiceId)).FirstOrDefault();
            if(result.EndDate != null)
            {
                rowAnimalCare.AddNotification(new Notification("RowAnimalCare.ProfessionalServicesAnimal", "Não é possivel alterar o profissional por que o serviço informado já foi finalizado"));
                return rowAnimalCare;
            }

            var petService = _rowAnimalCareRepository.GetPetServiceById(petServiceId);
            var newProfessional = _rowAnimalCareRepository.GetProfessionalById(newProfessionalId);
            rowAnimalCare.AnimailServices.Remove(result);
            result.AlterProfessional(newProfessional);
            rowAnimalCare.AnimailServices.Add(result);
            _rowAnimalCareRepository.UpdateRowAnimalCare(rowAnimalCare);
            return rowAnimalCare;
        }

        public RowAnimalCare AddPetServiceOnRowAnimalCare(RowAnimalCare rowAnimalCare, ProfessionalServicesAnimal professionalServices)
        {
            var existPosition = rowAnimalCare.AnimailServices.Where(x => x.ExecutionOrder.Equals(professionalServices.ExecutionOrder)).FirstOrDefault();

            if (existPosition == null)
            {
                rowAnimalCare.AnimailServices.Add(professionalServices);
                _rowAnimalCareRepository.UpdateRowAnimalCare(rowAnimalCare);
                return rowAnimalCare;
            }

            rowAnimalCare.AddNotification(new Notification("RowAnimalCare.ProfessionalServicesAnimal", $"O serviço {professionalServices.PetService.Description} " +
                $" não pode ser adicionado para ser executado na posição {professionalServices.ExecutionOrder}"));
            return rowAnimalCare;
        }
    }
}

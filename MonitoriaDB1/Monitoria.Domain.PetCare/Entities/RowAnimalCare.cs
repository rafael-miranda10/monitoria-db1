using Flunt.Notifications;
using Monitoria.Domain.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Monitoria.Domain.PetCare.Entities
{
    public class RowAnimalCare : Entity
    {
        private IList<ProfessionalServicesAnimal> _animalServices;

        public RowAnimalCare(AnimalPetCare animal)
        {
            AnimalPetCare = animal;
            ValueTotal = 0;
            _animalServices = new List<ProfessionalServicesAnimal>();


            AddNotifications(AnimalPetCare);
        }

        public AnimalPetCare AnimalPetCare { get; private set; }
        public decimal ValueTotal { get; private set; }
        public virtual IList<ProfessionalServicesAnimal> AnimailServices { get { return _animalServices.ToArray(); } }

        public void CalculatePriceTotal()
        {
            if (_animalServices.Count > 0)
                ValueTotal = _animalServices.Sum(x => x.PetService.ServiceValue);
        }

        public void AddProfessionalService(ProfessionalServicesAnimal profService)
        {
            if (profService.Invalid)
            {
                foreach (var item in profService.Notifications)
                {
                    AddNotification(new Notification("RowAnimalCare.List<ProfessionalServicesAnimal>", 
                        $"Não foi possível adicionar o atendimento! Motivo: {profService.PetService.Description} - {item.Message}"));
                }
            }

            if (profService.Valid)
                _animalServices.Add(profService);
        }
    }
}

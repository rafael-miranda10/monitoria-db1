using Flunt.Notifications;
using Monitoria.Domain.Registration.Entities;
using Monitoria.Domain.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Monitoria.Domain.PetCare.Entities
{
    public class RowAnimalCare : Entity
    {
        public RowAnimalCare()
        {

        }
        public RowAnimalCare( Guid animalId )
        {
            AnimalId = animalId;
            ValueTotal = 0;
            AnimailServices = new List<ProfessionalServicesAnimal>();
        }
        public RowAnimalCare(Guid animalId, List<ProfessionalServicesAnimal> animalsServices)
        {
            AnimalId = animalId;
            ValueTotal = 0;
            AnimailServices = animalsServices;
        }

        public Guid AnimalId { get; private set; }
        public decimal ValueTotal { get; private set; }
        public IList<ProfessionalServicesAnimal> AnimailServices { get; private set; }

        public void CalculatePriceTotal()
        {
            if (AnimailServices.Count > 0)
                ValueTotal = AnimailServices.Sum(x => x.PetService.ServiceValue);
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
                AnimailServices.Add(profService);
        }
    }
}

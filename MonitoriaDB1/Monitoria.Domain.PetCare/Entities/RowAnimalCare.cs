using Flunt.Notifications;
using Monitoria.Domain.Shared.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Monitoria.Domain.PetCare.Entities
{
    public class RowAnimalCare : Entity
    {
        public RowAnimalCare()
        {

        }
        public RowAnimalCare(AnimalPetCare animal)
        {
            AnimalPetCare = animal;
            ValueTotal = 0;

            AddNotifications(AnimalPetCare);
        }
        public RowAnimalCare(AnimalPetCare animal,List<ProfessionalServicesAnimal> animalsServices)
        {
            AnimalPetCare = animal;
            ValueTotal = 0;
            AnimailServices = animalsServices;

            AddNotifications(AnimalPetCare);
        }

        public AnimalPetCare AnimalPetCare { get; private set; }
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

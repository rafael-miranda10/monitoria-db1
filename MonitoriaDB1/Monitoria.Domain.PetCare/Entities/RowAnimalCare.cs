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
        public RowAnimalCare(Animal animal)
        {
            Animal = animal;
            ValueTotal = 0;
            AnimailServices = new List<ProfessionalServicesAnimal>();
        }
        public RowAnimalCare(Animal animal, List<ProfessionalServicesAnimal> animalsServices)
        {
            Animal = animal;
            ValueTotal = 0;
            AnimailServices = animalsServices;
        }

        public Animal Animal { get; private set; }
        public decimal ValueTotal { get; private set; }
        public IList<ProfessionalServicesAnimal> AnimailServices { get; private set; }

        public void CalculatePriceTotal(decimal value)
        {
            ValueTotal = value;
        }
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
        public void AddAnimalToRow(Animal animal)
        {
            Animal = animal;
            ValidadeAgeAnimal();
        }
        private void ValidadeAgeAnimal()
        {
            if(Animal.Age >= 10)
                AddNotification(new Notification("RowAnimalCare.Animal","Não é possivel atender animais com idade igual o maior que 10 anos!"));
        }
    }
}

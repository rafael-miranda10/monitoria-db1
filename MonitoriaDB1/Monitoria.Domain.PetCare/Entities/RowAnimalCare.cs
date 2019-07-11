using Monitoria.Domain.Shared.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Monitoria.Domain.PetCare.Entities
{
    public class RowAnimalCare: Entity
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
        public IList<ProfessionalServicesAnimal> AnimailServices { get { return _animalServices.ToArray(); } }

        private void CalculatePriceTotal()
        {
            ValueTotal = _animalServices.Sum(x => x.PetService.ServiceValue);
        }

        private void AddProfessionalService(ProfessionalServicesAnimal profService)
        {
            if (Valid)
                _animalServices.Add(profService);
        }
    }
}

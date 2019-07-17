using System.Collections.Generic;
using System.Linq;

namespace Monitoria.API.ViewModels.PetCare
{
    public class RowAnimalCareViewModel
    {
        private IList<ProfessionalServicesAnimalViewModel> _animalServices;

        public RowAnimalCareViewModel(AnimalPetCareViewModel animal)
        {
            AnimalPetCare = animal;
            ValueTotal = 0;
            _animalServices = new List<ProfessionalServicesAnimalViewModel>();
        }

        public AnimalPetCareViewModel AnimalPetCare { get; private set; }
        public decimal ValueTotal { get; private set; }
        public IList<ProfessionalServicesAnimalViewModel> AnimailServices { get { return _animalServices.ToArray(); } }
    }
}

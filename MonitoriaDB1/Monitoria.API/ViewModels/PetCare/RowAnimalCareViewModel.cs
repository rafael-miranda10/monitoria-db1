using Monitoria.API.ViewModels.Shared;
using System.Collections.Generic;

namespace Monitoria.API.ViewModels.PetCare
{
    public class RowAnimalCareViewModel : Entity
    {
        public RowAnimalCareViewModel()
        {

        }
        public RowAnimalCareViewModel(AnimalPetCareViewModel animal)
        {
            AnimalPetCare = animal;
            ValueTotal = 0;
            AnimailServices = new List<ProfessionalServicesAnimalViewModel>();
        }

        public AnimalPetCareViewModel AnimalPetCare { get; set; }
        public decimal ValueTotal { get; set; }
        public IList<ProfessionalServicesAnimalViewModel> AnimailServices { get; set;}
    }
}

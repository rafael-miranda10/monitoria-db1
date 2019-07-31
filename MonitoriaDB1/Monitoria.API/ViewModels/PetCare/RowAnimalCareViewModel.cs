using Monitoria.API.ViewModels.Registration;
using Monitoria.API.ViewModels.Shared;
using System;
using System.Collections.Generic;

namespace Monitoria.API.ViewModels.PetCare
{
    public class RowAnimalCareViewModel : Entity
    {
        public RowAnimalCareViewModel()
        {

        }
        public RowAnimalCareViewModel(Guid animalId)
        {
            AnimalId = animalId;
            ValueTotal = 0;
            AnimailServices = new List<ProfessionalServicesAnimalViewModel>();
        }

        public Guid AnimalId { get; private set; }
        public decimal ValueTotal { get; set; }
        public IList<ProfessionalServicesAnimalViewModel> AnimailServices { get; set;}
    }
}

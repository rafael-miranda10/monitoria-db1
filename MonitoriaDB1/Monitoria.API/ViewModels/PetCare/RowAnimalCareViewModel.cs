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
        public RowAnimalCareViewModel(AnimalViewModel animal)
        {
            Animal = animal;
            ValueTotal = 0;
        }

        public Guid AnimalId { get; private set; }
        public virtual AnimalViewModel Animal { get; set; }
        public decimal ValueTotal { get; set; }
        public IList<ProfessionalServicesAnimalViewModel> AnimailServices { get; set;}
    }
}

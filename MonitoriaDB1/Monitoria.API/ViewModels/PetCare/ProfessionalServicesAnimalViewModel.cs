using Monitoria.API.ViewModels.Shared;
using System;

namespace Monitoria.API.ViewModels.PetCare
{
    public class ProfessionalServicesAnimalViewModel : Entity
    {
        public ProfessionalServicesAnimalViewModel()
        {

        }
        public ProfessionalServicesAnimalViewModel(ProfessionalViewModel prof, PetServicesViewModel pService, string note)
        {
            Professional = prof;
            PetService = pService;
            StartDate = DateTime.Now;
            Note = note;
        }

        public ProfessionalViewModel Professional { get;  set; }
        public PetServicesViewModel PetService { get;  set; }
        public DateTime StartDate { get;  set; }
        public DateTime EndDate { get;  set; }
        public string Note { get;  set; }
        public RowAnimalCareViewModel RowAnimalCare { get; set; }
    }
}

using System;

namespace Monitoria.API.ViewModels.PetCare
{
    public class ProfessionalServicesAnimalViewModel
    {
        public ProfessionalServicesAnimalViewModel(ProfessionalViewModel prof, PetServicesViewModel pService, string note)
        {
            Professional = prof;
            PetService = pService;
            StartDate = DateTime.Now;
            Note = note;
        }

        public ProfessionalViewModel Professional { get; private set; }
        public PetServicesViewModel PetService { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string Note { get; private set; }
        public RowAnimalCareViewModel RowAnimalCare { get; private set; }
    }
}

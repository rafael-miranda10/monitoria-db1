using Monitoria.API.ViewModels.Shared;
using Monitoria.API.ViewModels.ValueObjects;

namespace Monitoria.API.ViewModels.PetCare
{
    public class ProfessionalViewModel : Entity
    {
        public ProfessionalViewModel()
        {

        }
        public ProfessionalViewModel(NameViewModel name, DocumentViewModel document, EmailViewModel email, AddressViewModel address, int jobPosition)
        {
            Name = name;
            Document = document;
            Email = email;
            Address = address;
            JobPosition = jobPosition;
           // ProfessionalServicesAnimalViewModel = professionalServicesAnimalViewModel;
        }

        public NameViewModel Name { get; set; }
        public DocumentViewModel Document { get; set; }
        public EmailViewModel Email { get; set; }
        public AddressViewModel Address { get; set; }
        public int JobPosition { get; set; }
        //public ProfessionalServicesAnimalViewModel ProfessionalServicesAnimalViewModel { get; set; }
    }
}

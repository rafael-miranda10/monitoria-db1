using Monitoria.API.ViewModels.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoria.API.ViewModels.PetCare
{
    public class ProfessionalViewModel
    {
        private IList<ProfessionalServicesAnimalViewModel> _animalServices;

        public ProfessionalViewModel(NameViewModel name, DocumentViewModel document, EmailViewModel email, AddressViewModel address, int jobPosition)
        {
            Name = name;
            Document = document;
            Email = email;
            Address = address;
            JobPosition = jobPosition;
            _animalServices = new List<ProfessionalServicesAnimalViewModel>();
        }

        public NameViewModel Name { get; private set; }
        public DocumentViewModel Document { get; private set; }
        public EmailViewModel Email { get; private set; }
        public AddressViewModel Address { get; private set; }
        public int JobPosition { get; private set; }
        public IList<ProfessionalServicesAnimalViewModel> AnimailServices { get { return _animalServices.ToArray(); } }
    }
}

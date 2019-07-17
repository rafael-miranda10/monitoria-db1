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

        public ProfessionalViewModel(Name name, Document document, Email email, Address address, int jobPosition)
        {
            Name = name;
            Document = document;
            Email = email;
            Address = address;
            JobPosition = jobPosition;
            _animalServices = new List<ProfessionalServicesAnimalViewModel>();
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public int JobPosition { get; private set; }
        public IList<ProfessionalServicesAnimalViewModel> AnimailServices { get { return _animalServices.ToArray(); } }
    }
}

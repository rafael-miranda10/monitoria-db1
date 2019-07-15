using Monitoria.Domain.PetCare.Enum;
using Monitoria.Domain.Shared.Entities;
using Monitoria.Domain.Shared.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace Monitoria.Domain.PetCare.Entities
{
    public class Professional : Entity
    {
        private IList<ProfessionalServicesAnimal> _animalServices;

        public Professional(Name name, Document document, Email email, Address address, ProfessionalEnum jobPosition)
        {
            Name = name;
            Document = document;
            Email = email;
            Address = address;
            JobPosition = jobPosition;
            _animalServices = new List<ProfessionalServicesAnimal>();

            AddNotifications(name, document, email, address);
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public ProfessionalEnum JobPosition { get; private set; }

        public virtual IList<ProfessionalServicesAnimal> AnimailServices { get { return _animalServices.ToArray(); } }

    }
}

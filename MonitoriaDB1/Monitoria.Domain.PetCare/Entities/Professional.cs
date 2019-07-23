using Monitoria.Domain.PetCare.Enum;
using Monitoria.Domain.Shared.Entities;
using Monitoria.Domain.Shared.ValueObjects;

namespace Monitoria.Domain.PetCare.Entities
{
    public class Professional : Entity
    {
        public Professional()
        {

        }
        public Professional(Name name, Document document, Email email, Address address, ProfessionalEnum jobPosition)
        {
            Name = name;
            Document = document;
            Email = email;
            Address = address;
            JobPosition = jobPosition;

            AddNotifications(name, document, email, address);
        }
        public Professional(Name name, Document document, Email email, Address address, ProfessionalEnum jobPosition, ProfessionalServicesAnimal professionalServicesAnimal)
        {
            Name = name;
            Document = document;
            Email = email;
            Address = address;
            JobPosition = jobPosition;
            ProfessionalServicesAnimal = professionalServicesAnimal;

            AddNotifications(name, document, email, address);
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public ProfessionalEnum JobPosition { get; private set; }
        public ProfessionalServicesAnimal ProfessionalServicesAnimal { get; private set; }
    }
}

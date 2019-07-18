using Monitoria.Infra.RepModels.Shared.Entity;
using Monitoria.Infra.RepModels.Shared.ValueObjects;
using Monitoria.Infra.RepoModels.PetCare.Enum;
using System.Collections.Generic;

namespace Monitoria.Infra.RepoModels.PetCare.Models
{
    public class Professional : Entity
    {
        public Professional()
        {
        }
        public Professional(NameRepModel name, DocumentRepModel document, EmailRepModel email, AddressRepModel address, ProfessionalEnum jobPosition, List<ProfessionalServicesAnimal> animalservices)
        {
            Name = name;
            Document = document;
            Email = email;
            Address = address;
            JobPosition = jobPosition;
            AnimailServices = animalservices;
        }

        public NameRepModel Name { get; private set; }
        public DocumentRepModel Document { get; private set; }
        public EmailRepModel Email { get; private set; }
        public AddressRepModel Address { get; private set; }
        public ProfessionalEnum JobPosition { get; private set; }
        public IList<ProfessionalServicesAnimal> AnimailServices { get; private set; }
    }
}

using Monitoria.Infra.RepModels.Shared.Entity;
using Monitoria.Infra.RepModels.Shared.ValueObjects;
using Monitoria.Infra.RepoModels.PetCare.Enum;

namespace Monitoria.Infra.RepoModels.PetCare.Models
{
    public class ProfessionalRepModel : Entity
    {
        public ProfessionalRepModel()
        {
        }
       
        public ProfessionalRepModel(NameRepModel name, DocumentRepModel document, EmailRepModel email, AddressRepModel address, ProfessionalEnum jobPosition)
        {
            Name = name;
            Document = document;
            Email = email;
            Address = address;
            JobPosition = jobPosition;
        }

        public NameRepModel Name { get; private set; }
        public DocumentRepModel Document { get; private set; }
        public EmailRepModel Email { get; private set; }
        public AddressRepModel Address { get; private set; }
        public ProfessionalEnum JobPosition { get; private set; }
    }
}

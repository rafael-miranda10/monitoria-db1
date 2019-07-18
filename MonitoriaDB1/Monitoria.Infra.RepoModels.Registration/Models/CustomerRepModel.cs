using Monitoria.Infra.RepModels.Shared.Entity;
using Monitoria.Infra.RepModels.Shared.ValueObjects;
using System.Collections.Generic;

namespace Monitoria.Infra.RepoModels.Registration.Models
{
    public class CustomerRepModel : Entity
    {
        public CustomerRepModel()
        {
        }
        public CustomerRepModel(NameRepModel name, DocumentRepModel document, EmailRepModel email, AddressRepModel address, List<AnimalRepModel> animals)
        {
            Name = name;
            Document = document;
            Email = email;
            Address = address;
            Animails = animals;
        }
        public NameRepModel Name { get; private set; }
        public DocumentRepModel Document { get; private set; }
        public EmailRepModel Email { get; private set; }
        public AddressRepModel Address { get; private set; }
        public virtual IList<AnimalRepModel> Animails { get; private set; }

    }
}

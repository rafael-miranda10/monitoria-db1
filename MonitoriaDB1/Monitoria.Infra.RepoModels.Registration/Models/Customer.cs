using Monitoria.Infra.RepModels.Shared.Entity;
using Monitoria.Infra.RepModels.Shared.ValueObjects;
using System.Collections.Generic;

namespace Monitoria.Infra.RepoModels.Registration.Models
{
    public class Customer : Entity
    {
        public Customer()
        {
        }
        public Customer(Name name, Document document, Email email, Address address, List<Animal> animals)
        {
            Name = name;
            Document = document;
            Email = email;
            Address = address;
            Animails = animals;
        }
        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public virtual IList<Animal> Animails { get; private set; }

    }
}

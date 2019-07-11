using Flunt.Validations;
using Monitoria.Infra.Shared.Entities;
using Monitoria.Infra.Shared.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace Monitoria.Domain.Registration.Entities
{
    public class Customer : Entity
    {
        private IList<Animal> _animals;

        public Customer(Name name, Document document, Email email, Address address)
        {
            Name = name;
            Document = document;
            Email = email;
            Address = address;
            _animals = new List<Animal>();

            AddNotifications(name, document, email, address);
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public IList<Animal> Animails { get { return _animals.ToArray(); } }

        public void AddAnimal(Animal animal)
        {
            var hasSameName = _animals.SingleOrDefault(x => x.Name == animal.Name);

            if (hasSameName != null)
            {
                AddNotifications(new Contract()
                .Requires()
                .IsNotNull(hasSameName, "Customer.Animals", "Você já tem um animal com o mesmo nome")
                );
            }

            if (Valid)
                _animals.Add(animal);

        }
    }
}

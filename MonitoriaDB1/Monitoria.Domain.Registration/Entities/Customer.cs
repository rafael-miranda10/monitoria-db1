using Flunt.Notifications;
using Monitoria.Domain.Shared.Entities;
using Monitoria.Domain.Shared.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace Monitoria.Domain.Registration.Entities
{
    public class Customer : Entity
    {
        public Customer()
        {

        }
        public Customer(Name name, Document document, Email email, Address address)
        {
            Name = name;
            Document = document;
            Email = email;
            Address = address;
            Animails = new List<Animal>();

            AddNotifications(name, document, email, address);
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public IList<Animal> Animails { get; private set; }

        public void AddAnimal(Animal animal)
        {
            var hasSameName = Animails.SingleOrDefault(x => x.Name == animal.Name);

            if (hasSameName != null)
            {
                AddNotification(new Notification("Customer.Animals", $"O cliente {Name.FirstName} já tem um animal chamado {animal.Name}"));
            }

            if (Valid)
                Animails.Add(animal);

        }
    }
}

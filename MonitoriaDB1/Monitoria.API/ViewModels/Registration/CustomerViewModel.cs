using Monitoria.API.ViewModels.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace Monitoria.API.ViewModels.Registration
{
    public class CustomerViewModel
    {
        private IList<AnimalViewModel> _animals;

        public CustomerViewModel(Name name, Document document, Email email, Address address)
        {
            Name = name;
            Document = document;
            Email = email;
            Address = address;
            _animals = new List<AnimalViewModel>();
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public IList<AnimalViewModel> Animails { get { return _animals.ToArray(); } }
    }
}

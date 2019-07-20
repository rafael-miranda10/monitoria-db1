using Flunt.Notifications;
using Monitoria.API.ViewModels.ValueObjects;
using System.Collections.Generic;

namespace Monitoria.API.ViewModels.Registration
{
    public class CustomerViewModel : Notifiable
    {
        public CustomerViewModel()
        {

        }
        public CustomerViewModel(NameViewModel name, DocumentViewModel document, EmailViewModel email, AddressViewModel address)
        {
            Name = name;
            Document = document;
            Email = email;
            Address = address;
            Animails = new List<AnimalViewModel>();

            AddNotifications(name, document, email, address);
        }

        public NameViewModel Name { get; set; }
        public DocumentViewModel Document { get; set; }
        public EmailViewModel Email { get; set; }
        public AddressViewModel Address { get; set; }
        public IList<AnimalViewModel> Animails { get; set; }
    }
}

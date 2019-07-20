using Flunt.Notifications;

namespace Monitoria.API.ViewModels.ValueObjects
{
    public class EmailViewModel : Notifiable
    {
        public EmailViewModel(string address)
        {
            Address = address;
        }

        public string Address { get; set; }
    }
}

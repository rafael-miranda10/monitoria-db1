using Flunt.Notifications;

namespace Monitoria.API.ViewModels.ValueObjects
{
    public class NameViewModel : Notifiable
    {
        public NameViewModel(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

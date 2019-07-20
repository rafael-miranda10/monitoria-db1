using Flunt.Notifications;

namespace Monitoria.API.ViewModels.ValueObjects
{
    public class DocumentViewModel : Notifiable
    {
        public DocumentViewModel(string number, int type)
        {
            Number = number;
            Type = type;
        }

        public string Number { get; set; }
        public int Type { get; set; }
    }
}

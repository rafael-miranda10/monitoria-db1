namespace Monitoria.Infra.RepModels.Shared.ValueObjects
{
    public class Email
    {
        public Email()
        {
        }
        public Email(string address)
        {
            Address = address;
        }
        public string Address { get; private set; }
    }
}

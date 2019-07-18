namespace Monitoria.Infra.RepModels.Shared.ValueObjects
{
    public class EmailRepModel
    {
        public EmailRepModel()
        {
        }
        public EmailRepModel(string address)
        {
            Address = address;
        }
        public string Address { get; private set; }
    }
}

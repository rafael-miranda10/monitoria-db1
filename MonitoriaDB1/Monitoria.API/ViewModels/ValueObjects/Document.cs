namespace Monitoria.API.ViewModels.ValueObjects
{
    public class Document
    {
        public Document(string number, int type)
        {
            Number = number;
            Type = type;
        }

        public string Number { get; private set; }
        public int Type { get; private set; }
    }
}

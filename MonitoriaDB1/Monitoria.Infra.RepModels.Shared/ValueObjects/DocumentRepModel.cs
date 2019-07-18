using Monitoria.Infra.RepModels.Shared.Enum;

namespace Monitoria.Infra.RepModels.Shared.ValueObjects
{
    public class DocumentRepModel
    {
        public DocumentRepModel()
        {
        }
        public DocumentRepModel(string number, DocumentEnum type)
        {
            Number = number;
            Type = type;
        }
        public string Number { get; private set; }
        public DocumentEnum Type { get; private set; }
    }
}

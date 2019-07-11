using System.ComponentModel;

namespace Monitoria.Infra.Shared.Enum
{
    public enum EDocumentType
    {
        [Description("CPF")]
        CPF = 1,
        [Description("CNPJ")]
        CNPJ = 2
    }
}

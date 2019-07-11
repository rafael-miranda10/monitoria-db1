using System.ComponentModel;

namespace Monitoria.Domain.Registration.Enum
{
    public enum EDocumentType
    {
        [Description("CPF")]
        CPF = 1,
        [Description("CNPJ")]
        CNPJ = 2
    }
}

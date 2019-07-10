using System.ComponentModel;

namespace Monitoria.Domain.Registration.Enum
{
    public enum SpeciesEnum
    {

        [Description("NÃO DEFINIDO")]
        None = 0,

        [Description("AVES")]
        Bird = 1,

        [Description("CANINA")]
        Canine = 2,

        [Description("FELINA")]
        Feline = 3,

        [Description("ROEDOR")]
        Rodent = 4,
    }
}

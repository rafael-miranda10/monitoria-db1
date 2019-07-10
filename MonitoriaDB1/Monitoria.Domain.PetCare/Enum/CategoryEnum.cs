using System.ComponentModel;

namespace Monitoria.Domain.PetCare.Enum
{
    public enum CategoryEnum
    {
        [Description("Estética Animal")]
        AnimalEsthetics = 1,

        [Description("Procedimento veterinário")]
        VeterinaryProcedure = 2,

        [Description("Atendimento Loja")]
        CustomerService = 3,
    }
}

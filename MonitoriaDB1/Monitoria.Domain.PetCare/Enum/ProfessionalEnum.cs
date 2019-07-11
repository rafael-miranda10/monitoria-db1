using System.ComponentModel;

namespace Monitoria.Domain.PetCare.Enum
{
    public enum ProfessionalEnum
    {

        [Description("VETERINÁRIO")]
        Veterinary = 1,

        [Description("Tosador")]
        AnimalHaircut = 2,

        [Description("Balconista")]
        Clerk = 3,
    }
}

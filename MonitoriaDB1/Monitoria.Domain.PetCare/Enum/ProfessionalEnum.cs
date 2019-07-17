﻿using System.ComponentModel;

namespace Monitoria.Domain.PetCare.Enum
{
    public enum ProfessionalEnum
    {
        [Description("VETERINÁRIO")]
        Veterinary = 1,

        [Description("Tosador")]
        AnimalHairCut = 2,

        [Description("Balconista")]
        Clerk = 3,
    }
}

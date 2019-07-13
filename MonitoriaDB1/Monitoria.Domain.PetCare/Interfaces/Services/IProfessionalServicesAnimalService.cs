﻿using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.Shared.Interfaces.Services;
using System.Collections.Generic;

namespace Monitoria.Domain.PetCare.Interfaces.Services
{
    public interface IProfessionalServicesAnimalService : IServiceBase<ProfessionalServicesAnimal>
    {
        IEnumerable<ProfessionalServicesAnimal> GetAllServicesByProfessional(Professional profissional);
    }
}

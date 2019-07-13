using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.PetCare.Enum;
using Monitoria.Domain.Shared.Interfaces.Services;
using System.Collections.Generic;

namespace Monitoria.Domain.PetCare.Interfaces.Services
{
    public interface IProfessionalService : IServiceBase<Professional>
    {
        IEnumerable<Professional> GetAllProfessionalByEnum(ProfessionalEnum type);
    }
}

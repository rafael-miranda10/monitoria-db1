using Monitoria.Application.Shared.Interfaces;
using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.PetCare.Enum;
using System.Collections.Generic;

namespace Monitoria.Application.PetCare.Interfaces
{
    public interface IProfessinalAppService : IAppServiceBase<Professional>
    {
        IEnumerable<Professional> GetAllProfessionalByEnum(ProfessionalEnum type);
    }
}

using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.PetCare.Enum;
using Monitoria.Domain.Shared.Interfaces.Repositories;
using System.Collections.Generic;

namespace Monitoria.Domain.PetCare.Interfaces.Repositories
{
    public interface IProfessionalRepository: IRepositoryBase<Professional>
    {
        IEnumerable<Professional> GetAllProfessionalByEnum(ProfessionalEnum type);
    }
}

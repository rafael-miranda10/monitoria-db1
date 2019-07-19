using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.PetCare.Enum;
using System.Collections.Generic;

namespace Monitoria.Domain.PetCare.Interfaces.Services
{
    public interface IProfessionalService 
    {
        IEnumerable<Professional> GetAllProfessionalByEnum(ProfessionalEnum type);
    }
}

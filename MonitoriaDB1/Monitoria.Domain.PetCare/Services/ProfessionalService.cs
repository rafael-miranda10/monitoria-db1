using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.PetCare.Enum;
using Monitoria.Domain.PetCare.Interfaces.Repositories;
using Monitoria.Domain.PetCare.Interfaces.Services;
using Monitoria.Domain.Shared.Services;
using System.Collections.Generic;

namespace Monitoria.Domain.PetCare.Services
{
    public class ProfessionalService : ServiceBase<Professional>, IProfessionalService
    {
        private readonly IProfessionalRepository _professionalRepository;

        public ProfessionalService(IProfessionalRepository professionalRepository): base(professionalRepository)
        {
            _professionalRepository = professionalRepository;
        }

        public IEnumerable<Professional> GetAllProfessionalByEnum(ProfessionalEnum type)
        {
            return _professionalRepository.GetAllProfessionalByEnum(type);
        }
    }
}

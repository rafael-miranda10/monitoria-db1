using Monitoria.Application.PetCare.Interfaces;
using Monitoria.Application.Shared.Apps;
using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.PetCare.Enum;
using Monitoria.Domain.PetCare.Interfaces.Services;
using System.Collections.Generic;

namespace Monitoria.Application.PetCare.Apps
{
    public class ProfessinalAppService : AppServiceBase<Professional>, IProfessinalAppService
    {
        private readonly IProfessionalService _professionalService;

        public ProfessinalAppService(IProfessionalService professionalService) : base(professionalService)
        {
            _professionalService = professionalService;
        }

        public IEnumerable<Professional> GetAllProfessionalByEnum(ProfessionalEnum type)
        {
            return _professionalService.GetAllProfessionalByEnum(type);
        }
    }
}

using Monitoria.Application.PetCare.Interfaces;
using Monitoria.Application.Shared.Apps;
using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.PetCare.Interfaces.Services;

namespace Monitoria.Application.PetCare.Apps
{
    public class PetServicesAppService : AppServiceBase<PetServices>, IPetServicesAppService
    {
        private readonly IPetServicesService _petServicesService;

        public PetServicesAppService(IPetServicesService petServicesService) : base(petServicesService)
        {
        }
    }
}

using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.PetCare.Interfaces.Repositories;
using Monitoria.Domain.PetCare.Interfaces.Services;
using Monitoria.Domain.Shared.Services;

namespace Monitoria.Domain.PetCare.Services
{
    public class PetServicesService: ServiceBase<PetServices>, IPetServicesService
    {
        private readonly IPetServicesRepository _petServicesRepository; 

        public PetServicesService(IPetServicesRepository petServicesRepository) : base(petServicesRepository)
        {
            _petServicesRepository = petServicesRepository;
        }
    }
}

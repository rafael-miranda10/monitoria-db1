using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.PetCare.Interfaces.Repositories;
using Monitoria.Infra.Data.Contexts;

namespace Monitoria.Infra.Data.Repositories.PetCare
{
    public class PetServicesRepository : RepositoryBase<PetServices, PetCareContext>, IPetServicesRepository
    {
        private readonly PetCareContext _context;

        public PetServicesRepository(PetCareContext context) : base(context)
        {
            _context = context;
        }
    }
}

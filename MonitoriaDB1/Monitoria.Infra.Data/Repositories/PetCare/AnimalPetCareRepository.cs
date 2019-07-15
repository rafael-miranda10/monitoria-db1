using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.PetCare.Interfaces.Repositories;
using Monitoria.Infra.Data.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace Monitoria.Infra.Data.Repositories.PetCare
{
    public class AnimalPetCareRepository : RepositoryBase<AnimalPetCare, PetCareContext>, IAnimalPetCareRepository
    {
        private readonly PetCareContext _context;

        public AnimalPetCareRepository(PetCareContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<AnimalPetCare> GetByAnimalPetCareName(string Name)
        {
            return _context.Set<AnimalPetCare>().Where(x => x.Name.Equals(Name)).AsEnumerable();
        }
    }
}

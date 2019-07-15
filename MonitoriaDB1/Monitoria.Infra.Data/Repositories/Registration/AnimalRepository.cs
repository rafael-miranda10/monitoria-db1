using System.Collections.Generic;
using System.Linq;
using Monitoria.Domain.Registration.Entities;
using Monitoria.Domain.Registration.Interfaces.Repositories;
using Monitoria.Infra.Data.Contexts;

namespace Monitoria.Infra.Data.Repositories.Registration
{
    public class AnimalRepository : RepositoryBase<Animal, RegistrationContext>, IAnimalRepository
    {
        private readonly RegistrationContext _context;

        public AnimalRepository(RegistrationContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Animal> GetByAnimalName(string name)
        {
            //var query = (from entity in _context.Set<Animal>().AsEnumerable()
            //             where entity.Name.Equals(name)
            //             select entity);
            //return query;

            return _context.Set<Animal>().Where(x => x.Name.Equals(name)).AsEnumerable();
        }
    }
}

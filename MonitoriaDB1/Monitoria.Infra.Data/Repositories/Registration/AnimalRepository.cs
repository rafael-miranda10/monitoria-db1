using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Monitoria.Domain.Registration.Entities;
using Monitoria.Domain.Registration.Interfaces.Repositories;
using Monitoria.Infra.Data.Contexts;
using Monitoria.Infra.RepoModels.Registration.Models;

namespace Monitoria.Infra.Data.Repositories.Registration
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly RegistrationContext _context;
        private readonly IMapper _mapper;

        public AnimalRepository(RegistrationContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<Animal> GetAll()
        {
            var query = _context.Animal.AsEnumerable();
            var list = _mapper.Map<IEnumerable<AnimalRepModel>, IEnumerable<Animal>>(query);
            return list;
        }
        public Animal GetById(Guid id)
        {
            var result = _context.Animal.Find(id);
            var animal = _mapper.Map<AnimalRepModel, Animal>(result);
            return animal;
        }
        public IEnumerable<Animal> GetByAnimalName(string name)
        {
            var query =  _context.Animal.Where(x => x.Name.Equals(name)).AsEnumerable();
            var list = _mapper.Map<IEnumerable<AnimalRepModel>, IEnumerable<Animal>>(query);
            return list;
        }

       public IEnumerable<Animal> GetByCustomerId(Guid customerId)
        {
            var query = _context.Animal.Where(x => x.CustomerId.Equals(customerId)).AsEnumerable();
            var list = _mapper.Map<IEnumerable<AnimalRepModel>, IEnumerable<Animal>>(query);
            return list;
        }
    }
}

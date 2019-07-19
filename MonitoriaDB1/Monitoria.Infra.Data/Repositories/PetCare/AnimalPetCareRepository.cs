using AutoMapper;
using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.PetCare.Interfaces.Repositories;
using Monitoria.Infra.Data.Contexts;
using Monitoria.Infra.RepoModels.PetCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Monitoria.Infra.Data.Repositories.PetCare
{
    public class AnimalPetCareRepository : IAnimalPetCareRepository
    {
        private readonly PetCareContext _context;
        private readonly IMapper _mapper;

        public AnimalPetCareRepository(PetCareContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<AnimalPetCare> GetAllAnimal()
        {
            var query = _context.AnimalPetCare.AsEnumerable();
            var list = _mapper.Map<IEnumerable<AnimalPetCareRepModel>, IEnumerable<AnimalPetCare>>(query);
            return list;
        }

        public AnimalPetCare GetAnimalPetCareById(Guid id)
        {
            var result = _context.AnimalPetCare.Find(id);
            var animal = _mapper.Map<AnimalPetCareRepModel, AnimalPetCare>(result);
            return animal;
        }

        public IEnumerable<AnimalPetCare> GetByAnimalPetCareName(string Name)
        {
            return _context.Set<AnimalPetCare>().Where(x => x.Name.Equals(Name)).AsEnumerable();
        }

        public IEnumerable<AnimalPetCare> GetByCustomerId(Guid customerId)
        {
            var query = _context.AnimalPetCare.Where(x => x.CustomerId.Equals(customerId)).AsEnumerable();
            var list = _mapper.Map<IEnumerable<AnimalPetCareRepModel>, IEnumerable<AnimalPetCare>>(query);
            return list;
        }
    }
}

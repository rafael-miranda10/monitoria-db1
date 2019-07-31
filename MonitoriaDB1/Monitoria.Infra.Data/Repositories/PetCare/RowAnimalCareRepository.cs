using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.PetCare.Interfaces.Repositories;
using Monitoria.Domain.Registration.Entities;
using Monitoria.Infra.Data.Contexts;
using Monitoria.Infra.RepoModels.PetCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Monitoria.Infra.Data.Repositories.PetCare
{
    public class RowAnimalCareRepository : IRowAnimalCareRepository
    {
        private readonly PetCareContext _context;
        private readonly IMapper _mapper;

        public RowAnimalCareRepository(PetCareContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddRowAnimalCare(RowAnimalCare rowAnimalCare)
        {
            var rowAnimalCareRepModel = _mapper.Map<RowAnimalCare, RowAnimalCareRepModel>(rowAnimalCare);
            _context.RowAnimalCare.Add(rowAnimalCareRepModel);
            _context.SaveChanges();
        }

        public bool ExistingEntity(RowAnimalCare rowAnimalCare)
        {
            var existing = GetEntityEqualTo(rowAnimalCare);
            return existing != null;
        }

        public IEnumerable<RowAnimalCare> GetAllRowAnimalCare()
        {
            var query = _context.RowAnimalCare.AsEnumerable();
            var list = _mapper.Map<IEnumerable<RowAnimalCareRepModel>, IEnumerable<RowAnimalCare>>(query);
            return list;
        }

        public IEnumerable<RowAnimalCare> GetAllServicesOfAnimal(Animal animal)
        {
            var query = _context.RowAnimalCare.Where(x => x.AnimalId.Equals(animal.Id)).AsEnumerable();
            var list = _mapper.Map<IEnumerable<RowAnimalCareRepModel>, IEnumerable<RowAnimalCare>>(query);
            return list;
        }

        public RowAnimalCare GetEntityEqualTo(RowAnimalCare rowAnimalCare)
        {
            var query = (from entity in _context.RowAnimalCare.AsEnumerable()
                         where entity.Equals(rowAnimalCare)
                         select entity).FirstOrDefault();
            var result = _mapper.Map<RowAnimalCareRepModel, RowAnimalCare>(query);
            return result;
        }

        public RowAnimalCare GetRowAnimalCareById(Guid id)
        {
            var result = _context.RowAnimalCare.Find(id);
            var rowAnimalCareRepModel = _mapper.Map<RowAnimalCareRepModel, RowAnimalCare>(result);
            return rowAnimalCareRepModel;
        }

        public void RemoveRowAnimalCare(RowAnimalCare rowAnimalCare)
        {
            var rowAnimalCareRepModel = _mapper.Map<RowAnimalCare, RowAnimalCareRepModel>(rowAnimalCare);
            _context.RowAnimalCare.Remove(rowAnimalCareRepModel);
            _context.SaveChanges();
        }

        public void RemoveRowAnimalCareById(Guid id)
        {
            var result = _context.RowAnimalCare.Find(id);
            if (result != null)
                _context.RowAnimalCare.Remove(result);
        }

        public void UpdateRowAnimalCare(RowAnimalCare rowAnimalCare)
        {
            var rowAnimalCareRepModel = _mapper.Map<RowAnimalCare, RowAnimalCareRepModel>(rowAnimalCare);
            _context.RowAnimalCare.Attach(rowAnimalCareRepModel);
            _context.Entry(rowAnimalCareRepModel).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}

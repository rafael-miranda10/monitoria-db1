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
            var result = _context.RowAnimalCare.AsNoTracking().Where(x => x.Id.Equals(id))
                .Include(x => x.AnimailServices).AsNoTracking()
                .FirstOrDefault();
            var rowAnimalCareRepModel = _mapper.Map<RowAnimalCareRepModel, RowAnimalCare>(result);
            return rowAnimalCareRepModel;
        }

        public Professional GetProfessionalById(Guid Id)
        {
            var result = _context.Professional.AsNoTracking().Where(x => x.Id.Equals(Id)).FirstOrDefault();
            var professionalRepModel = _mapper.Map<ProfessionalRepModel, Professional>(result);
            return professionalRepModel;
        }
        public PetServices GetPetServiceById(Guid Id)
        {
            var result = _context.PetServices.AsNoTracking().Where(x => x.Id.Equals(Id)).FirstOrDefault();
            var petServicesRepModel = _mapper.Map<PetServicesRepModel, PetServices>(result);
            return petServicesRepModel;
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

        private void RemoveProfessionalServicesAnimal(IEnumerable<ProfessionalServicesAnimalRepModel> list)
        {
            _context.ProfessionalServicesAnimal.RemoveRange(list);
        }
        private void AddProfessionalServicesAnimal(IEnumerable<ProfessionalServicesAnimalRepModel> list)
        {
            _context.ProfessionalServicesAnimal.AddRange(list);
        }

        public void UpdateRowAnimalCare(RowAnimalCare rowAnimalCare)
        {
            var rowAnimalCareRepModel = _mapper.Map<RowAnimalCare, RowAnimalCareRepModel>(rowAnimalCare);
            var tracked = GetRowAnimalCareByIdTracked(rowAnimalCareRepModel.Id);
            RemoveProfessionalServicesAnimal(tracked.AnimailServices);
            ModifiedStateEntity(tracked);
            _context.SaveChanges();

            _context.RowAnimalCare.Attach(rowAnimalCareRepModel);
            _context.Entry(rowAnimalCareRepModel).State = EntityState.Modified;
            AddProfessionalServicesAnimal(rowAnimalCareRepModel.AnimailServices);
            _context.SaveChanges();
        }
        private RowAnimalCareRepModel GetRowAnimalCareByIdTracked(Guid id)
        {
            var result = _context.RowAnimalCare.Where(x => x.Id.Equals(id))
                .Include(x => x.AnimailServices)
                .FirstOrDefault();
            return result;
        }
        private void ModifiedStateEntity(RowAnimalCareRepModel rowAnimalCare)
        {
            _context.Entry(rowAnimalCare).State = EntityState.Detached;
            _context.SaveChanges();
        }
    }
}

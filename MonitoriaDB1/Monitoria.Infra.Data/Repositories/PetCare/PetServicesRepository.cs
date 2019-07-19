using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.PetCare.Interfaces.Repositories;
using Monitoria.Infra.Data.Contexts;
using Monitoria.Infra.RepoModels.PetCare.Models;

namespace Monitoria.Infra.Data.Repositories.PetCare
{
    public class PetServicesRepository : IPetServicesRepository
    {
        private readonly PetCareContext _context;
        private readonly IMapper _mapper;

        public PetServicesRepository(PetCareContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void AddPetServices(PetServices petServices)
        {
            var petServicesRepModel = _mapper.Map<PetServices, PetServicesRepModel>(petServices);
            _context.PetServices.Add(petServicesRepModel);
            _context.SaveChanges();
        }

        public void UpdatePetServices(PetServices petServices)
        {
            var petServicesRepModel = _mapper.Map<PetServices, PetServicesRepModel>(petServices);
            _context.PetServices.Attach(petServicesRepModel);
            _context.Entry(petServicesRepModel).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemovePetServices(PetServices petServices)
        {
            var petServicesRepModel = _mapper.Map<PetServices, PetServicesRepModel>(petServices);
            _context.PetServices.Remove(petServicesRepModel);
            _context.SaveChanges();
        }

        public void RemovePetServicesById(Guid id)
        {
            var result = _context.PetServices.Find(id);
            if (result != null)
                _context.PetServices.Remove(result);
        }

        public IEnumerable<PetServices> GetAllPetServices()
        {
            var query = _context.PetServices.AsEnumerable();
            var list = _mapper.Map<IEnumerable<PetServicesRepModel>, IEnumerable<PetServices>>(query);
            return list;
        }

        public IEnumerable<PetServices> GetByPetServicesDescription(string description)
        {
            var query = _context.PetServices.Where(x => x.Description.Equals(description)).AsEnumerable();
            var list = _mapper.Map<IEnumerable<PetServicesRepModel>, IEnumerable<PetServices>>(query);
            return list;
        }

        public PetServices GetPetServicesById(Guid id)
        {
            var result = _context.PetServices.Find(id);
            var petService = _mapper.Map<PetServicesRepModel, PetServices>(result);
            return petService;
        }

        public PetServices GetEntityEqualTo(PetServices petServices)
        {
            var query = (from entity in _context.PetServices.AsEnumerable()
                         where entity.Equals(petServices)
                         select entity).FirstOrDefault();
            var result = _mapper.Map<PetServicesRepModel, PetServices>(query);
            return result;
        }

        public bool ExistingEntity(PetServices petServices)
        {
            var existing = GetEntityEqualTo(petServices);
            return existing != null;
        }
    }
}


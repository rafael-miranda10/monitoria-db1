using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.PetCare.Enum;
using Monitoria.Domain.PetCare.Interfaces.Repositories;
using Monitoria.Infra.Data.Contexts;
using Monitoria.Infra.RepoModels.PetCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Monitoria.Infra.Data.Repositories.PetCare
{
    public class ProfessionalRepository : IProfessionalRepository
    {
        private readonly PetCareContext _context;
        private readonly IMapper _mapper;

        public ProfessionalRepository(PetCareContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }


        public IEnumerable<Professional> GetAllProfessionalByEnum(ProfessionalEnum type)
        {
            var query = _context.Professional.Where(x => x.JobPosition.Equals(type)).AsEnumerable();
            var list = _mapper.Map<IEnumerable<ProfessionalRepModel>, IEnumerable<Professional>>(query);
            return list;
        }
       
        public Professional GetEntityEqualTo(Professional professional)
        {
            var query = (from entity in _context.Professional.AsEnumerable()
                         where entity.Equals(professional)
                         select entity).FirstOrDefault();
            var result = _mapper.Map<ProfessionalRepModel, Professional>(query);
            return result;
        }

        public bool ExistingEntity(Professional professional)
        {
            var existing = GetEntityEqualTo(professional);
            return existing != null;
        }

        public void AddProfessional(Professional professional)
        {
            var professionalRepModel = _mapper.Map<Professional, ProfessionalRepModel>(professional);
            _context.Professional.Add(professionalRepModel);
            _context.SaveChanges();
        }

        public void UpdateProfessional(Professional professional)
        {
            var professionalRepModel = _mapper.Map<Professional, ProfessionalRepModel>(professional);
            _context.Professional.Attach(professionalRepModel);
            _context.Entry(professionalRepModel).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemoveProfessional(Professional professional)
        {
            var professionalRepModel = _mapper.Map<Professional, ProfessionalRepModel>(professional);
            _context.Professional.Remove(professionalRepModel);
            _context.SaveChanges();
        }

        public void RemoveProfessionalById(Guid id)
        {
            var result = _context.Professional.Find(id);
            if (result != null)
                _context.Professional.Remove(result);
        }

        public IEnumerable<Professional> GetAllProfessional()
        {
            var query = _context.Professional.AsEnumerable();
            var list = _mapper.Map<IEnumerable<ProfessionalRepModel>, IEnumerable<Professional>>(query);
            return list;
        }

        public IEnumerable<Professional> GetByProfessionalName(string name)
        {
            var query = _context.Professional.Where(x => x.Name.FirstName.Equals(name)).AsEnumerable();
            var list = _mapper.Map<IEnumerable<ProfessionalRepModel>, IEnumerable<Professional>>(query);
            return list;
        }

        public Professional GetProfessionalById(Guid id)
        {
            var result = _context.Professional.Find(id);
            var professional = _mapper.Map<ProfessionalRepModel, Professional>(result);
            return professional;
        }
    }
}

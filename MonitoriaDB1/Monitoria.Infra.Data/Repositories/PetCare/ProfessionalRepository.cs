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
    public class ProfessionalRepository : RepositoryBase<Professional, PetCareContext>, IProfessionalRepository
    {
        private readonly PetCareContext _context;
        private readonly IMapper _mapper;

        public ProfessionalRepository(PetCareContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public override void Add(Professional professional)
        {
            var professionalRepModel = _mapper.Map<Professional, ProfessionalRepModel>(professional);
            _context.Professional.Add(professionalRepModel);
            _context.SaveChanges();
        }
        public override void Update(Professional professional)
        {
            var professionalRepModel = _mapper.Map<Professional, ProfessionalRepModel>(professional);
            _context.Professional.Attach(professionalRepModel);
            _context.Entry(professionalRepModel).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public override void Remove(Professional professional)
        {
            var professionalRepModel = _mapper.Map<Professional, ProfessionalRepModel>(professional);
            _context.Professional.Remove(professionalRepModel);
            _context.SaveChanges();
        }

        public IEnumerable<Professional> GetAllProfessionalByEnum(ProfessionalEnum type)
        {
            var query = _context.Professional.Where(x => x.JobPosition.Equals(type)).AsEnumerable();
            var list = _mapper.Map<IEnumerable<ProfessionalRepModel>, IEnumerable<Professional>>(query);
            return list;
        }
        public override IEnumerable<Professional> GetAll()
        {
            var query = _context.Professional.AsEnumerable();
            var list = _mapper.Map<IEnumerable<ProfessionalRepModel>, IEnumerable<Professional>>(query);
            return list;
        }

        public override Professional GetById(Guid id)
        {
            var result = _context.Professional.Find(id);
            var professional = _mapper.Map<ProfessionalRepModel, Professional>(result);
            return professional;
        }

        public override void RemoveById(Guid id)
        {
            var result = _context.Professional.Find(id);
            if (result != null)
                _context.Professional.Remove(result);
        }

        public override Professional GetEntityEqualTo(Professional professional)
        {
            var query = (from entity in _context.Professional.AsEnumerable()
                         where entity.Equals(professional)
                         select entity).FirstOrDefault();
            var result = _mapper.Map<ProfessionalRepModel, Professional>(query);
            return result;
        }

        public override bool ExistingEntity(Professional professional)
        {
            var existing = GetEntityEqualTo(professional);
            return existing != null;
        }
    }
}

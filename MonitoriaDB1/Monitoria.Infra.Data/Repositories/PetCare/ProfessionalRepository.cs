using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.PetCare.Enum;
using Monitoria.Domain.PetCare.Interfaces.Repositories;
using Monitoria.Infra.Data.Contexts;
using Monitoria.Infra.RepoModels.PetCare.Models;
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
            return _context.Set<Professional>().Where(x => x.JobPosition.Equals(type)).AsEnumerable();
        }
    }
}

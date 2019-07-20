using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Monitoria.Domain.PetCare.Entities;
using Monitoria.Domain.PetCare.Interfaces.Repositories;
using Monitoria.Infra.Data.Contexts;
using Monitoria.Infra.RepoModels.PetCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Monitoria.Infra.Data.Repositories.PetCare
{
    public class ProfessionalServicesAnimalRepository :  IProfessionalServicesAnimalRepository
    {
        private readonly PetCareContext _context;
        private readonly IMapper _mapper;

        public ProfessionalServicesAnimalRepository(PetCareContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddProfissionalServiceAnimal(ProfessionalServicesAnimal profissionalServiceAnimal)
        {
            var profissionalServiceAnimalRepModel = _mapper.Map<ProfessionalServicesAnimal, ProfessionalServicesAnimalRepModel>(profissionalServiceAnimal);
            _context.ProfessionalServicesAnimal.Add(profissionalServiceAnimalRepModel);
            _context.SaveChanges();
        }

        public bool ExistingEntity(ProfessionalServicesAnimal profissionalServiceAnimal)
        {
            var existing = GetEntityEqualTo(profissionalServiceAnimal);
            return existing != null;
        }

        public IEnumerable<ProfessionalServicesAnimal> GetAllProfissionalServiceAnimal()
        {
            var query = _context.ProfessionalServicesAnimal.AsEnumerable();
            var list = _mapper.Map<IEnumerable<ProfessionalServicesAnimalRepModel>, IEnumerable<ProfessionalServicesAnimal>>(query);
            return list;
        }

        public IEnumerable<ProfessionalServicesAnimal> GetAllServicesByProfessional(Professional profissional)
        {
            return _context.Set<ProfessionalServicesAnimal>().Where(x => x.Professional.Equals(profissional)).AsEnumerable();
        }

        public ProfessionalServicesAnimal GetEntityEqualTo(ProfessionalServicesAnimal profissionalServiceAnimal)
        {
            var query = (from entity in _context.ProfessionalServicesAnimal.AsEnumerable()
                         where entity.Equals(profissionalServiceAnimal)
                         select entity).FirstOrDefault();
            var result = _mapper.Map<ProfessionalServicesAnimalRepModel, ProfessionalServicesAnimal>(query);
            return result;
        }

        public ProfessionalServicesAnimal GetProfissionalServiceAnimalById(Guid id)
        {
            var result = _context.ProfessionalServicesAnimal.Find(id);
            var professional = _mapper.Map<ProfessionalServicesAnimalRepModel, ProfessionalServicesAnimal>(result);
            return professional;
        }

        public void RemoveProfissionalServiceAnimal(ProfessionalServicesAnimal profissionalServiceAnimal)
        {
            var ProfessionalServicesAnimalRepModel = _mapper.Map<ProfessionalServicesAnimal, ProfessionalServicesAnimalRepModel>(profissionalServiceAnimal);
            _context.ProfessionalServicesAnimal.Remove(ProfessionalServicesAnimalRepModel);
            _context.SaveChanges();
        }

        public void RemoveProfissionalServiceAnimalById(Guid id)
        {
            var result = _context.ProfessionalServicesAnimal.Find(id);
            if (result != null)
                _context.ProfessionalServicesAnimal.Remove(result);
        }

        public void UpdateProfissionalServiceAnimal(ProfessionalServicesAnimal profissionalServiceAnimal)
        {
            var profissionalServiceAnimalRepModel = _mapper.Map<ProfessionalServicesAnimal, ProfessionalServicesAnimalRepModel>(profissionalServiceAnimal);
            _context.ProfessionalServicesAnimal.Attach(profissionalServiceAnimalRepModel);
            _context.Entry(profissionalServiceAnimalRepModel).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public IEnumerable<ProfessionalServicesAnimal> GetAllServicesOfAnimal(AnimalPetCare animal)
        {
            return _context.Set<ProfessionalServicesAnimal>().Where(x => x.RowAnimalCare.AnimalPetCare.Equals(animal)).AsEnumerable();
        }
    }
}

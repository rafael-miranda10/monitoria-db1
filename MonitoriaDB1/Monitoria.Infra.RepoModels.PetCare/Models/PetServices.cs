using Monitoria.Infra.RepModels.Shared.Entity;
using Monitoria.Infra.RepoModels.PetCare.Enum;
using System.Collections.Generic;

namespace Monitoria.Infra.RepoModels.PetCare.Models
{
    public class PetServices : Entity
    {
        public PetServices()
        {
        }
        public PetServices(string descricao, CategoryEnum category, string checkList, decimal serviceValue, bool active, List<ProfessionalServicesAnimal> animalservices )
        {
            Description = descricao;
            Category = category;
            CheckList = checkList;
            Active = active;
            ServiceValue = serviceValue;
            AnimailServices = animalservices;
        }

        public string Description { get; private set; }
        public CategoryEnum Category { get; private set; }
        public string CheckList { get; private set; }
        public decimal ServiceValue { get; private set; }
        public bool Active { get; private set; }
        public virtual IList<ProfessionalServicesAnimal> AnimailServices { get; private set; }
    }
}

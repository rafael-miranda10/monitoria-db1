using Monitoria.Infra.RepModels.Shared.Entity;
using Monitoria.Infra.RepoModels.PetCare.Enum;

namespace Monitoria.Infra.RepoModels.PetCare.Models
{
    public class PetServicesRepModel : Entity
    {
        public PetServicesRepModel()
        {
        }
        public PetServicesRepModel(string descricao, CategoryEnum category, string checkList, decimal serviceValue, bool active, ProfessionalServicesAnimalRepModel professionalServicesAnimal)
        {
            Description = descricao;
            Category = category;
            CheckList = checkList;
            Active = active;
            ServiceValue = serviceValue;
            ProfessionalServicesAnimal = professionalServicesAnimal;
        }

        public string Description { get; private set; }
        public CategoryEnum Category { get; private set; }
        public string CheckList { get; private set; }
        public decimal ServiceValue { get; private set; }
        public bool Active { get; private set; }
        public ProfessionalServicesAnimalRepModel ProfessionalServicesAnimal { get; private set; }
    }
}

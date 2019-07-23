using Monitoria.API.ViewModels.Shared;
using Newtonsoft.Json;

namespace Monitoria.API.ViewModels.PetCare
{
    public class PetServicesViewModel : Entity
    {
        public PetServicesViewModel()
        {

        }
        public PetServicesViewModel(string descricao, int category, string checkList, decimal serviceValue, bool active)
        {
            Description = descricao;
            Category = category;
            CheckList = checkList;
            Active = active;
            ServiceValue = serviceValue;
            //ProfessionalServicesAnimalViewModel = new ProfessionalServicesAnimalViewModel();
        }

        public string Description { get; set; }
        public int Category { get; set; }
        public string CheckList { get; set; }
        public decimal ServiceValue { get; set; }
        public bool Active { get; set; }
        //[JsonIgnore]
        //public ProfessionalServicesAnimalViewModel ProfessionalServicesAnimalViewModel { get; set; }
    }
}

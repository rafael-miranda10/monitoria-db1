using Monitoria.API.ViewModels.Shared;
using System.Collections.Generic;

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
            AnimailServices = new List<ProfessionalServicesAnimalViewModel>();
        }

        public string Description { get; set; }
        public int Category { get; set; }
        public string CheckList { get; set; }
        public decimal ServiceValue { get; set; }
        public bool Active { get; set; }
        public IList<ProfessionalServicesAnimalViewModel> AnimailServices { get; set; }
    }
}

using System.Collections.Generic;
using System.Linq;

namespace Monitoria.API.ViewModels.PetCare
{
    public class PetServicesViewModel
    {
        private IList<ProfessionalServicesAnimalViewModel> _animalServices;

        public PetServicesViewModel(string descricao, int category, string checkList, decimal serviceValue, bool active)
        {
            Description = descricao;
            Category = category;
            CheckList = checkList;
            Active = active;
            ServiceValue = serviceValue;
            _animalServices = new List<ProfessionalServicesAnimalViewModel>();
        }

        public string Description { get; private set; }
        public int Category { get; private set; }
        public string CheckList { get; private set; }
        public decimal ServiceValue { get; private set; }
        public bool Active { get; private set; }
        public IList<ProfessionalServicesAnimalViewModel> AnimailServices { get { return _animalServices.ToArray(); } }
    }
}

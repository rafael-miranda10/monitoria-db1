using Monitoria.API.ViewModels.Shared;
using System;

namespace Monitoria.API.ViewModels.PetCare
{
    public class ProfessionalServicesAnimalViewModel : Entity
    {
        public ProfessionalServicesAnimalViewModel()
        {

        }
        public ProfessionalServicesAnimalViewModel(Guid profissionalId, Guid petServiceId, int Order, string note)
        {
            ProfissionalId = profissionalId;
            PetServiceId = petServiceId;
            ExecutionOrder = Order;
            Note = note;
        }

        public Guid ProfissionalId { get;  set; }
        public Guid PetServiceId { get;  set; }
        public string Note { get;  set; }
        public int ExecutionOrder { get; set; }
        //public Guid RowAnimalCareId { get; set; }
    }
}

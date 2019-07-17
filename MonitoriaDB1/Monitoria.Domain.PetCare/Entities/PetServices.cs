using Flunt.Validations;
using Monitoria.Domain.PetCare.Enum;
using Monitoria.Domain.Shared.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Monitoria.Domain.PetCare.Entities
{
    public class PetServices : Entity
    {
        private IList<ProfessionalServicesAnimal> _animalServices;

        public PetServices(string descricao, CategoryEnum category, string checkList, decimal serviceValue, bool active)
        {
            Description = descricao;
            Category = category;
            CheckList = checkList;
            Active = active;
            ServiceValue = serviceValue;
            _animalServices = new List<ProfessionalServicesAnimal>();

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Description, 3, "PetServices.Description", "A descrição deve conter pelo menos 3 caracteres")
                .HasMaxLen(Description, 50, "PetServices.Description", "A descrição deve conter até 50 caracteres")
                .HasMinLen(CheckList, 3, "PetServices.CheckList", "O checklist deve conter pelo menos 3 caracteres")
                .HasMaxLen(CheckList, 200, "PetServices.CheckList", "O checklist deve conter até 200 caracteres")
                .IsGreaterThan(ServiceValue, 0, "PetServices.ServiceValue", "O valor deve ser maior que zero")
            );

        }

        public string Description { get; private set; }
        public CategoryEnum Category { get; private set; }
        public string CheckList { get; private set; }
        public decimal ServiceValue { get; private set; }
        public bool Active { get; private set; }
        public IList<ProfessionalServicesAnimal> AnimailServices { get { return _animalServices.ToArray(); } }

    }
}

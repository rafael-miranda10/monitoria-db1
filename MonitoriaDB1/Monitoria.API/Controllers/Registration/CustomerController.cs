using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Monitoria.API.ViewModels.Registration;
using Monitoria.Application.Registration.Interfaces;
using Monitoria.Domain.Registration.Entities;
using Monitoria.Domain.Shared.Enum;
using Monitoria.Domain.Shared.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace Monitoria.API.Controllers.Registration
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerAppService _customerAppService;
        private readonly IMapper _mapper;
        //_mapper.Map<IEnumerable<AnimalRepModel>, IEnumerable<Animal>>(query);
        public CustomerController(ICustomerAppService customerAppService, IMapper mapper)
        {
            _customerAppService = customerAppService;
            _mapper = mapper;
        }

        [Route("adicionar")]
        [HttpPost]
        public IActionResult Post(CustomerViewModel customerVM)
        {
            //var animal = new Animal("Cindy", 2, SpeciesEnum.Canine, true);
            //var customer = new Customer(new Name("Enzo Cirilo", "De Oliveira"), new Document("09052751013", DocumentEnum.CPF), new Email("enzo.cirilo@gmail.com"), new Address("Rua Nochete", "450", "Vila Operária", "Presidente Prudente", "São Paulo", "Brasil", "19033040"));
            //customer.AddAnimal(animal);
            var customer = _mapper.Map<CustomerViewModel, Customer>(customerVM);
            _customerAppService.AddCustomer(customer);

            return Ok(customer);
        }
        [Route("pesquisar")]
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get(string name)
        {
            //"Djalma Jorge"
            return _customerAppService.GetByCustomerName(name).ToList();
        }
        [Route("pesquisar-todos")]
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            var result = _customerAppService.GetAllCustomer().ToList();
            return result;
        }
    }
}
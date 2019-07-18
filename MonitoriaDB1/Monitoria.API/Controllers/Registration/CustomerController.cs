using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Monitoria.Application.Registration.Interfaces;
using Monitoria.Domain.Registration.Entities;
using Monitoria.Domain.Shared.Enum;
using Monitoria.Domain.Shared.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Monitoria.API.Controllers.Registration
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerAppService _customerAppService;
        public CustomerController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }

        [Route("adicionar")]
        [HttpPost]
        public IActionResult Post()
        {
            var animal = new Animal("Greg Jr", 2, SpeciesEnum.Canine, true);
            var customer = new Customer(new Name("Djalma Jorge Jr", "De Oliveira"), new Document("09052751013", DocumentEnum.CPF), new Email("djalma.jorge@gmail.com"), new Address("Rua Nochete", "450", "Vila Operária", "Presidente Prudente", "São Paulo", "Brasil", "19033040"));
            customer.AddAnimal(animal);
            _customerAppService.Add(customer);

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
            var result = _customerAppService.GetAll().ToList();
            return result;
        }
    }
}
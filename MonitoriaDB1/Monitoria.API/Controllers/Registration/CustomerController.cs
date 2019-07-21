using AutoMapper;
using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;
using Monitoria.API.ViewModels.Registration;
using Monitoria.Application.Registration.Interfaces;
using Monitoria.Domain.Registration.Entities;
using System;
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

        public CustomerController(ICustomerAppService customerAppService, IMapper mapper)
        {
            _customerAppService = customerAppService;
            _mapper = mapper;
        }

        [Route("addCustomer")]
        [HttpPost]
        public IActionResult AddCustomer(CustomerViewModel customerVM)
        {
            var customer = _mapper.Map<CustomerViewModel, Customer>(customerVM);

            if (!customer.Notifications.Any())
            {
                try
                {
                    _customerAppService.AddCustomer(customer);
                    //return Ok(customerVM);
                    return Ok(new { success = true });
                }
                catch (Exception ex)
                {
                    return BadRequest($"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
                }
            }
            else
            {
                return BadRequest(new { errors = customer.Notifications });
            }
        }

        [Route("addAnimalCustomer")]
        [HttpPost]
        public IActionResult addAnimalCustomer(AnimalViewModel animalVM, Guid IdToSearch)
        {
            var animal = _mapper.Map<AnimalViewModel, Animal>(animalVM);

            if (!animal.Notifications.Any())
            {
                try
                {
                    var customer = _customerAppService.GetCostomerById(IdToSearch);
                    if (customer != null)
                    {
                        customer.AddAnimal(animal);
                        if (!customer.Notifications.Any())
                            _customerAppService.AddCustomerAnimals(customer);
                    }
                    else
                    {
                        animal.AddNotification(new Notification("Customer", $"O cliente não foi encontrado"));
                    }

                    if (customer.Notifications.Any())
                        return BadRequest(new { errors = animal.Notifications });


                    return Ok(new { success = true });
                }
                catch (Exception ex)
                {
                    return BadRequest($"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
                }
            }
            else
            {
                return BadRequest(new { errors = animal.Notifications });
            }
        }


        [Route("GetCustomersByFirstName")]
        [HttpGet]
        public ActionResult<IEnumerable<CustomerViewModel>> Get(string name)
        {
            try
            {
                var customer = _customerAppService.GetByCustomerName(name);
                if (customer != null)
                {
                    var customerVM = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(customer);
                    return Ok(customerVM);
                }

                return BadRequest($"Não foi possivel encontrar resultados para {name}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }

        }
        [Route("GetAllcustomers")]
        [HttpGet]
        public ActionResult<IEnumerable<CustomerViewModel>> GetAllcustomers()
        {
            try
            {
                var customer = _customerAppService.GetAllCustomer();
                if (customer != null)
                {
                    var customerVM = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(customer);
                    return Ok(customerVM);
                }

                return BadRequest($"Não foi possivel encontrar resultados ");
            }
            catch (Exception ex)
            {
                return BadRequest($"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }
        [Route("RemoveCustomer")]
        [HttpPost]
        public IActionResult RemoveCustomer(Guid customerId)
        {

            try
            {
                _customerAppService.RemoveCostomerById(customerId);
                return Ok($"Customer com o ID: { customerId} removido com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }

        }
    }
}
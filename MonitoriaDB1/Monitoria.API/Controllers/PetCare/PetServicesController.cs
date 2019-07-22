using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Monitoria.API.ViewModels.PetCare;
using Monitoria.Application.PetCare.Interfaces;
using Monitoria.Domain.PetCare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Monitoria.API.Controllers.PetCare
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetServicesController : ControllerBase
    {
        private readonly IPetServicesAppService _petServicesAppService;
        private readonly IMapper _mapper;

        public PetServicesController(IPetServicesAppService petServicesAppService, IMapper mapper)
        {
            _petServicesAppService = petServicesAppService;
            _mapper = mapper;
        }

        [Route("addPetServices")]
        [HttpPost]
        public IActionResult addPetServices(PetServicesViewModel petServicesVM)
        {
            var petServices = _mapper.Map<PetServicesViewModel, PetServices>(petServicesVM);

            if (!petServices.Notifications.Any())
            {
                try
                {
                    _petServicesAppService.AddPetServices(petServices);
                    return Ok(new { success = true });
                }
                catch (Exception ex)
                {
                    return BadRequest($"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
                }
            }
            else
            {
                return BadRequest(new { errors = petServices.Notifications });
            }
        }
        [Route("UpdatePetServices")]
        [HttpPost]
        public IActionResult UpdatePetServices(PetServicesViewModel petServicesVM)
        {
            var petServices = _mapper.Map<PetServicesViewModel, PetServices>(petServicesVM);

            if (!petServices.Notifications.Any())
            {
                try
                {
                    _petServicesAppService.UpdatePetServices(petServices);
                    return Ok(new { success = true });
                }
                catch (Exception ex)
                {
                    return BadRequest($"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
                }
            }
            else
            {
                return BadRequest(new { errors = petServices.Notifications });
            }
        }

        [Route("RemovePetServicesById")]
        [HttpPost]
        public IActionResult RemovePetServicesById(Guid petServicesId)
        {
            try
            {
                _petServicesAppService.RemovePetServicesById(petServicesId);
                return Ok($"O serviço com o ID: { petServicesId} removido com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        [Route("RemovePetServices")]
        [HttpPost]
        public IActionResult RemovePetServices(PetServicesViewModel petServicesVM)
        {
            try
            {
                var petServices = _mapper.Map<PetServicesViewModel, PetServices>(petServicesVM);
                _petServicesAppService.RemovePetServices(petServices);
                return Ok($"O serviço com o ID: { petServices.Id.ToString()} removido com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }
        [Route("GetAllPetServices")]
        [HttpGet]
        public ActionResult<IEnumerable<PetServicesViewModel>> GetAllPetServices()
        {
            try
            {
                var petServices = _petServicesAppService.GetAllPetServices();
                if (petServices != null)
                {
                    var petServicesVM = _mapper.Map<IEnumerable<PetServices>, IEnumerable<PetServicesViewModel>>(petServices);
                    return Ok(petServicesVM);
                }

                return BadRequest($"Não foi possivel encontrar resultados ");
            }
            catch (Exception ex)
            {
                return BadRequest($"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }
        [Route("GetPetServicesByDescription")]
        [HttpGet]
        public ActionResult<IEnumerable<PetServicesViewModel>> GetPetServicesByDescription(string description)
        {
            try
            {
                var petServices = _petServicesAppService.GetByPetServicesDescription(description);
                if (petServices != null)
                {
                    var petServicesVM = _mapper.Map<IEnumerable<PetServices>, IEnumerable<PetServicesViewModel>>(petServices);
                    return Ok(petServicesVM);
                }

                return BadRequest($"Não foi possivel encontrar resultados para {description}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        [Route("GetPetServicesById")]
        [HttpGet]
        public ActionResult<PetServicesViewModel> GetPetServicesById(Guid Id)
        {
            try
            {
                var petServices = _petServicesAppService.GetPetServicesById(Id);
                if (petServices != null)
                {
                    var petServicesVM = _mapper.Map<PetServices, PetServicesViewModel>(petServices);
                    return Ok(petServicesVM);
                }

                return BadRequest($"Não foi possivel encontrar resultados para o Id:  {Id.ToString()}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

    }
}
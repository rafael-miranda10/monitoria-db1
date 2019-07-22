using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Monitoria.API.ViewModels.PetCare;
using Monitoria.Application.PetCare.Interfaces;
using Monitoria.Domain.PetCare.Entities;

namespace Monitoria.API.Controllers.PetCare
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionalController : ControllerBase
    {
        private readonly IProfessinalAppService _professionalAppService;
        private readonly IMapper _mapper;

        public ProfessionalController(IProfessinalAppService professionalAppService, IMapper mapper)
        {
            _professionalAppService = professionalAppService;
            _mapper = mapper;
        }

        [Route("addProfessional")]
        [HttpPost]
        public IActionResult addProfessional(ProfessionalViewModel professionalVM)
        {
            var professional = _mapper.Map<ProfessionalViewModel, Professional>(professionalVM);

            if (!professional.Notifications.Any())
            {
                try
                {
                    _professionalAppService.AddProfessional(professional);
                    return Ok(new { success = true });
                }
                catch (Exception ex)
                {
                    return BadRequest($"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
                }
            }
            else
            {
                return BadRequest(new { errors = professional.Notifications });
            }
        }
        [Route("UpdateProfessional")]
        [HttpPost]
        public IActionResult UpdateProfessional(ProfessionalViewModel professionalVM)
        {
            var professional = _mapper.Map<ProfessionalViewModel, Professional>(professionalVM);

            if (!professional.Notifications.Any())
            {
                try
                {
                    _professionalAppService.UpdateProfessional(professional);
                    return Ok(new { success = true });
                }
                catch (Exception ex)
                {
                    return BadRequest($"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
                }
            }
            else
            {
                return BadRequest(new { errors = professional.Notifications });
            }
        }
        [Route("GetAllProfessionals")]
        [HttpGet]
        public ActionResult<IEnumerable<ProfessionalViewModel>> GetAllProfessionals()
        {
            try
            {
                var professional = _professionalAppService.GetAllProfessional();
                if (professional != null)
                {
                    var professionalVM = _mapper.Map<IEnumerable<Professional>, IEnumerable<ProfessionalViewModel>>(professional);
                    return Ok(professionalVM);
                }

                return BadRequest($"Não foi possivel encontrar resultados ");
            }
            catch (Exception ex)
            {
                return BadRequest($"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }
        [Route("GetProfessionalByFirstName")]
        [HttpGet]
        public ActionResult<IEnumerable<ProfessionalViewModel>> GetProfessionalByFirstName(string name)
        {
            try
            {
                var professional = _professionalAppService.GetByProfessionalName(name);
                if (professional != null)
                {
                    var professionalVM = _mapper.Map<IEnumerable<Professional>, IEnumerable<ProfessionalViewModel>>(professional);
                    return Ok(professionalVM);
                }

                return BadRequest($"Não foi possivel encontrar resultados para {name}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }

        }
        [Route("GetProfessionalByJobPosition")]
        [HttpGet]
        public ActionResult<IEnumerable<ProfessionalViewModel>> GetProfessionalByJobPosition(int jobPosition)
        {
            try
            {
                var professional = _professionalAppService.GetAllProfessionalByEnum(jobPosition);
                if (professional != null)
                {
                    var professionalVM = _mapper.Map<IEnumerable<Professional>, IEnumerable<ProfessionalViewModel>>(professional);
                    return Ok(professionalVM);
                }

                return BadRequest($"Não foi possivel encontrar resultados para o cargo informado");
            }
            catch (Exception ex)
            {
                return BadRequest($"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }

        }

        [Route("RemoveProfessionalById")]
        [HttpPost]
        public IActionResult RemoveProfessionalById(Guid professionalId)
        {

            try
            {
                _professionalAppService.RemoveProfessionalById(professionalId);
                return Ok($"Professional com o ID: { professionalId} removido com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        [Route("RemoveProfessional")]
        [HttpPost]
        public IActionResult RemoveProfessional(ProfessionalViewModel professionalVM)
        {
            try
            {
                var professional = _mapper.Map<ProfessionalViewModel, Professional>(professionalVM);
                _professionalAppService.RemoveProfessional(professional);
                return Ok($"Professional com o ID: { professional.Id.ToString()} removido com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }
    }
}
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Monitoria.API.ViewModels.PetCare;
using Monitoria.Application.PetCare.Interfaces;
using Monitoria.Domain.PetCare.Entities;
using System;
using System.Linq;

namespace Monitoria.API.Controllers.PetCare
{
    [Route("api/[controller]")]
    [ApiController]
    public class RowAnimalCareController : ControllerBase
    {
        private readonly IRowAnimalCareAppService _rowAnimalCareAppService;
        private readonly IMapper _mapper;

        public RowAnimalCareController(IRowAnimalCareAppService rowAnimalCareAppService, IMapper mapper)
        {
            _rowAnimalCareAppService = rowAnimalCareAppService;
            _mapper = mapper;
        }

        [Route("addRowAnimalCare")]
        [HttpPost]
        public IActionResult addRowAnimalCare(RowAnimalCareViewModel rowAnimalCareVM)
        {
            var rowAnimalCare = _mapper.Map<RowAnimalCareViewModel, RowAnimalCare>(rowAnimalCareVM);

            if (!rowAnimalCare.Notifications.Any())
            {
                try
                {
                    _rowAnimalCareAppService.AddRowAnimalCare(rowAnimalCare);
                    return Ok(new { success = true });
                }
                catch (Exception ex)
                {
                    return BadRequest($"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
                }
            }
            else
            {
                return BadRequest(new { errors = rowAnimalCare.Notifications });
            }
        }

        [Route("startServiceOnRow")]
        [HttpPost]
        public IActionResult startServiceOnRow(Guid rowAnimalCareId, Guid petCareServiceId)
        {
                try
                {
                    _rowAnimalCareAppService.StartPetCareServiceOnRow(rowAnimalCareId, petCareServiceId);
                    return Ok(new { success = true });
                }
                catch (Exception ex)
                {
                    return BadRequest($"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
                }
        }
        [Route("endServiceOnRow")]
        [HttpPost]
        public IActionResult endServiceOnRow(Guid rowAnimalCareId, Guid petCareServiceId)
        {
            try
            {
                _rowAnimalCareAppService.EndPetCareServiceOnRow(rowAnimalCareId, petCareServiceId);
                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                return BadRequest($"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }
        [Route("calculateValueTotalOnRow")]
        [HttpPost]
        public IActionResult calculateValueTotalOnRow(Guid rowAnimalCareId)
        {
            try
            {
                _rowAnimalCareAppService.calculateValueTotalOnRow(rowAnimalCareId);
                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                return BadRequest($"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        [Route("AlterProfessionalPerformerService")]
        [HttpPost]
        public IActionResult AlterProfessionalPerformerService(Guid rowAnimalCareId, Guid petServiceId, Guid newProfessionalId)
        {
            try
            {
                _rowAnimalCareAppService.AlterProfessionalService(rowAnimalCareId, petServiceId, newProfessionalId);
                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                return BadRequest($"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        [Route("AddNewPetServiceOnRow")]
        [HttpPost]
        public IActionResult AddNewPetServiceOnRow(Guid rowAnimalCareId, ProfessionalServicesAnimalViewModel professionalPetServices)
        {
            try
            {
                var serviceOnRow = _mapper.Map<ProfessionalServicesAnimalViewModel, ProfessionalServicesAnimal>(professionalPetServices);

                if (!serviceOnRow.Notifications.Any())
                {
                    var result =_rowAnimalCareAppService.AddPetServiceOnRowAnimalCare(rowAnimalCareId, serviceOnRow);
                    if (!result.Notifications.Any())
                        return Ok(new { success = true });

                    return BadRequest(new { errors = result.Notifications });
                }

                return BadRequest(new { errors = serviceOnRow.Notifications });
            }
            catch (Exception ex)
            {
                return BadRequest($"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }
    }
}
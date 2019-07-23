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
    }
}
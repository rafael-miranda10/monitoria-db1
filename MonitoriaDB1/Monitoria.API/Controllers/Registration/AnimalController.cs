using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monitoria.Application.Registration.Interfaces;
using Monitoria.Domain.Registration.Entities;
using Monitoria.Domain.Shared.Enum;

namespace Monitoria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalAppService _animalAppService;

        public AnimalController(IAnimalAppService animalAppService)
        {
            _animalAppService = animalAppService;
        }

        // GET api/animal
        [HttpGet]
        public ActionResult<IEnumerable<Animal>> Get()
        {
            // return new string[] { "maradona","Astor", "Sad", "Greg" };

            //var json = JsonConvert.SerializeObject(aList);
            return _animalAppService.GetAll().ToArray();
        }

        // POST api/animal
        [Route("adicionar")]
        [HttpPost]
        public void Post()
        {
            var animal = new Animal("Greg", 2,SpeciesEnum.Canine, true);
            _animalAppService.Add(animal);

        }
    }
}
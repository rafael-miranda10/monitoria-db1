using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Monitoria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        // GET api/animal
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "maradona","Astor", "Sad", "Greg" };
        }
    }
}
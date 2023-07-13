using Microsoft.AspNetCore.Mvc;

namespace GymClientControl.Controllers.v1.Client
{
    [ApiController]
    [Route("api/v1/Clients")]
    public class ClientsController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok("Metodo ainda nao implementado");
        }

        [HttpPost()]
        public IActionResult Post(string newClientInputModel)
        {
            return Ok("Metodo ainda nao implementado");
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Servicios.BusinessLogic.Intefaces;
using Servicios.Models;
using Servicios.WebApi.Models;

namespace Servicios.WebApi.Controllers
{
    [Route("api/Motocicleta")]
    [Authorize]
    public class MotocicletaController : ControllerBase
    {
        private readonly IMotocicletaLogic _logic;

        public MotocicletaController(IMotocicletaLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_logic.GetById(id));
        }

        [HttpGet]
        //[Route("ListaPaginadaMotocicleta")]
        public IActionResult Get()
        {
            return Ok(_logic.GetList());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Motocicleta usuario)
        {
            if (!ModelState.IsValid) return BadRequest();
            return Ok(_logic.Insert(usuario));
        }

        [HttpPut]
        public IActionResult Put([FromBody]Motocicleta usuario)
        {
            if (ModelState.IsValid && _logic.Update(usuario))
            {
                return Ok(new { Message = "The Supplier is Updated" });
            }

            return BadRequest();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id != 0)
            {
                return Ok(_logic.Delete(new Motocicleta() { Id = id}));
            }

            return BadRequest();

        }

    }
}
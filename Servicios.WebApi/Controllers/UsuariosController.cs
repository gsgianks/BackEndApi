using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Servicios.BusinessLogic.Intefaces;
using Servicios.Models;
using Servicios.WebApi.Models;

namespace Servicios.WebApi.Controllers
{
    [Route("api/Usuarios")]
    [Authorize]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosLogic _logic;

        public UsuariosController(IUsuariosLogic logic)
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
        public IActionResult GetList()
        {
            return Ok(_logic.GetList());
        }

        [HttpPost]
        [Route("ListaPaginadaUsuarios")]
        public IActionResult GetPaginatedSupplier([FromBody] GetPaginatedSupplier request)
        {
            return Ok(_logic.UsuariosListaPaginada(request.Page, request.Rows));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Usuarios usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_logic.Insert(usuario));
        }

        [HttpPut]
        public IActionResult Put([FromBody]Usuarios usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_logic.Update(usuario));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            return Ok(_logic.Delete(new Usuarios() { Id = id }));
        }

    }
}
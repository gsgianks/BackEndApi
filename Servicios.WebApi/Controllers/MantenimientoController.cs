using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Servicios.BusinessLogic.Intefaces;
using Servicios.Models;
using Servicios.Models.Base;
using Servicios.Models.Taller;
using Servicios.WebApi.Common;
using Servicios.WebApi.Models;
using System;
using System.IO;
using System.Net.Http.Headers;

namespace Servicios.WebApi.Controllers
{
    [Route("api/Mantenimiento")]
    [Authorize]
    public class MantenimientoController : ControllerBase
    {
        private readonly IMantenimientoLogic _logic;

        public MantenimientoController(IMantenimientoLogic logic)
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
        //[Route("ListaPaginadaMantenimiento")]
        public IActionResult Get()
        {
            return Ok(_logic.GetList());
        }

        //[HttpPost]
        //[Route("ListaPaginada")]
        //public IActionResult ListaPaginada([FromBody] PaginacionModel model)
        //{
        //    return Ok(_logic.ListaPaginadaMotocycleta(model.Page, model.Rows, model.Id));
        //}

        [HttpPost]
        public IActionResult Post([FromBody] Mantenimiento dto)
        {
            if (!ModelState.IsValid) return BadRequest();
            return Ok(_logic.Insert(dto));
        }

        [HttpPut]
        public IActionResult Put([FromBody]Mantenimiento usuario)
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
                return Ok(_logic.Delete(new Mantenimiento() { Id = id}));
            }

            return BadRequest();

        }

    }
}
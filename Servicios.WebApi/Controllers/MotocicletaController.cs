using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Servicios.BusinessLogic.Intefaces;
using Servicios.Models;
using Servicios.Models.Base;
using Servicios.WebApi.Common;
using Servicios.WebApi.Models;
using System;
using System.IO;
using System.Net.Http.Headers;

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
        [Route("ListaPaginada")]
        public IActionResult ListaPaginada([FromBody] PaginacionModel model)
        {
            return Ok(_logic.ListaPaginadaMotocycleta(model.Page, model.Rows, model.Id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Motocicleta usuario)
        {
            if (!ModelState.IsValid) return BadRequest();
            return Ok(_logic.Insert(usuario));
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("Upload")]
        public IActionResult Upload()
        {
            AnswerModel result = new AnswerModel();

            try
            {
                var file = Request.Form.Files[0];
                //var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Util.GetFilePath();//Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    //var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    result.Description = Util.GetFilePathRead()+fileName;
                }
                else
                {
                    result.Code = 99;
                    result.Description = "Archivo no guardado";
                }
            }
            catch (Exception ex)
            {
                //return StatusCode(500, "Internal server error");
                result.Code = 99;
                result.Description = "Error en la aplicación";
            }

            return Ok(new { code = result.Code, description = result.Description });
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tarefa_Api.Services;
using TCC_API.Infrastructure.Repository;

namespace Tarefa_Api.Controllers
{
    [Route("api/[controller]")]
    public class UsuariosController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { api = true });

        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Post([FromBody]Usuarios usuario, [FromServices] UsuariosServices services)
        {
            if (ModelState.IsValid)
            {
                return Ok(services.AddUsuario(usuario));
            }
            else
            {
                return BadRequest();
            }
           
        }
    }
}

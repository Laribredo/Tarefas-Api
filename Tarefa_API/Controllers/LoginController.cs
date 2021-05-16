using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tarefa_Api.Services;
using TCC_API.DTO;
using TCC_API.Infrastructure.Enums;
using TCC_API.Infrastructure.Repository;
using TCC_API.Services;

namespace Tarefa_Api.Controllers
{

    [Route("api/[controller]")]
    public class LoginController : Controller
    {

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Ok(new { api = true });

        }


        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody]RequestLoginDTO request,[FromServices]UsuariosServices service)
        {
            if (ModelState.IsValid)
            {
                Usuarios log = service.Login(request);
                if (log == null)
                    return NotFound(new { message = "Usuário ou senha inválidos" });

                var token = TokenService.GenerateToken(log);
                log.senha = "";
                return Ok(new
                {
                    usuario = log,
                    token_ = token
                });
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

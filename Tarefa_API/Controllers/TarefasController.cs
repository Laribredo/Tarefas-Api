using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Tarefa_Api.Infrastructure.Repository;
using Tarefa_Api.Services;

namespace Tarefa_Api.Controllers
{
    [Route("api/[controller]")]
    public class TarefasController : Controller
    {
        [HttpGet]
        [Authorize]
        public IActionResult GetAll([FromServices] TarefasService tarefas)
        {
            return Ok(tarefas.GetTarefas());
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetAll(Guid id,[FromServices] TarefasService tarefas)
        {
            return Ok(tarefas.GetTarefasById(id));
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add([FromBody] Tarefas request, [FromServices] TarefasService tarefas)
        {
            if(ModelState.IsValid)
            {
                return Ok(tarefas.AddTarefas(request));
            }
            else
            {
                return BadRequest();
            }
            
        }

        [HttpPut]
        [Authorize]
        public IActionResult Update([FromBody] Tarefas request, [FromServices] TarefasService tarefas)
        {
            if (ModelState.IsValid)
            {
                return Ok(tarefas.UpdateTarefa(request));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(Guid id, [FromServices] TarefasService tarefas)
        {
            return Ok(tarefas.RemoveTarefasById(id));
        }
    }
}

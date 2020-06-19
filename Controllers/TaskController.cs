using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ApiToDoList.Repositories;
using ApiToDoList.Models;
using ApiToDoList.Interface;

namespace ApiToDoList.Controllers
{
    [ApiController]
    [Route("v1/task")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _repository;

        public TaskController(ITaskRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("")]
        [Authorize]
        public IActionResult Get()
        {
            return Ok(_repository.Get());
        }

        [HttpPost]
        [Route("")]
        [Authorize]
        public IActionResult Post([FromBody] Task task)
        {
            if (string.IsNullOrEmpty(task.Description) || task.IdUser == 0)
                return NotFound("Os campos de descrição e usuário são obrigatórios");
            _repository.Create(task);
            return Ok("Tarefa inserida");
        }

        [HttpPut]
        [Route("")]
        [Authorize]
        public IActionResult Put([FromBody] Task task)
        {
            if (task.Id == 0)
                return NotFound("O campo id da tarefa é obrigatório");
            _repository.Update(task);
            return Ok("Tarefa atualizada");
        }

        [HttpDelete]
        [Route("")]
        [Authorize]
        public IActionResult Delete([FromBody] Task task)
        {
            if (task.Id == 0)
                return NotFound("O campo id da tarefa é obrigatório");
            _repository.Delete(task);
            return Ok("Tarefa removida");
        }

        [HttpPut]
        [Route("changeState")]
        [Authorize]
        public IActionResult ChangeState([FromBody] Task task)
        {
            if (task.Id == 0)
                return NotFound("O campo id da tarefa é obrigatório");
            _repository.ChangeState(task);
            return Ok("Tarefa atualizada");
        }
    }
}
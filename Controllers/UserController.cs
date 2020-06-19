using Microsoft.AspNetCore.Mvc;
using ApiToDoList.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using ApiToDoList.Services;
using ApiToDoList.Repositories;
using ApiToDoList.Interface;

namespace ApiToDoList.Controllers
{
    [ApiController]
    [Route("v1/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        public ActionResult<dynamic> Get([FromBody] User model)
        {
            var user = _repository.Get(model);
            if (user == null)
                return NotFound("Usuário ou senha inválidos");

            var token = TokenService.GenerateToken(user);

            return Ok(new { user = new { Id = user.Id, Name = user.Name }, token = token });
        }

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public ActionResult Post([FromBody] User user)
        {
            if (string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Password))
                return NotFound("Os campos de descrição e usuário são obrigatórios");
            _repository.Create(user);
            return Ok("Usuário inserido");
        }
    }
}
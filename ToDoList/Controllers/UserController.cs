using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<UsersDTO>> Post([FromBody] UsersDTO users)
        {
            var UsersDTO = _service.Register(users);
            if(UsersDTO!=null)
                return UsersDTO;
            return BadRequest("Registration Failed");
        }

        [Route("Login")]
        [HttpPost]
        public async Task<ActionResult<UsersDTO>> Put([FromBody]UsersDTO users)
        {
            var UsersDTO = _service.Login(users);
            if (UsersDTO != null)
                return Ok(UsersDTO);
            return BadRequest("Login Failed");
        }

    }
}

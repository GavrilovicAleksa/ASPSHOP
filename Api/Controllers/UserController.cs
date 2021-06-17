using Application;
using Application.Commands.User;
using Application.DataTransfer;
using Application.DataTransfer.User;
using Application.Queries.User;
using Application.Searches;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UseCaseExecutor executor;

        public UserController(UseCaseExecutor executor)
        {
            this.executor = executor;
        }

        [HttpGet]
        //[Authorize]
        public IActionResult Get(
            [FromQuery] UserSearch search,
            [FromServices] IGetUsersQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id,
            [FromServices] UserSearch search,
           [FromServices] IGetSingleUserQuery query)
        {
            search.Id = id;
            return Ok(executor.ExecuteQuery(query, search));
        }

        [HttpPost]
        public void Post([FromBody] UserDto dto,
            [FromServices] IRegisterUserCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }

        [HttpDelete("{id}")]
        public void Delete([FromBody] DeleteUserDto dto,
            [FromServices] IDeleteUserCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }

        [HttpPut]
        public void Put(UserDto dto,
            [FromServices] IUpdateUserCommand command)
        {
            executor.ExecuteCommand(command, dto);
        }
    }
}

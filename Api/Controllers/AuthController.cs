using Api.Core;
using Api.Core.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly JwtManager manager;

        public AuthController(JwtManager manager)
        {
            this.manager = manager;
        }

        [HttpPost("login", Name = "Post")]
        public IActionResult Post(  [FromBody] LoginRequest request)
        {
            var token = manager.MakeToken(request.Username, request.Password);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(new { token });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Jwt_Test.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticateService authService;
        public LoginController(IAuthenticateService authenticateService)
        {
            this.authService = authenticateService;
        }



        [Route("api/login")]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult CheckLogin([FromBody] LoginInfo loginInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Request");
            }
            string token;
            if (authService.IsAuthenticated(loginInfo, out token))
            {
                return Ok(token);
            }
            return BadRequest("Invalid Request");
        }
    }
}

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
        [Route("Login")]
        [AllowAnonymous]
        [HttpGet]
        public IActionResult CheckLogin(string userId, string userPwd)
        {
            if (userId == "colin" && userPwd == "123")
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Nbf,$"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}") ,
                    new Claim (JwtRegisteredClaimNames.Exp,$"{new DateTimeOffset(DateTime.Now.AddMinutes(30)).ToUnixTimeSeconds()}"),
                    new Claim(ClaimTypes.Name,userId)
                };
                var key = new SymmetricKeyWrapProvider(Encoding.UTF8.GetBytes(Const.SecurityKey));
            }
        }
    }
}

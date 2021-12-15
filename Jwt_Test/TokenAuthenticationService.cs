using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace Jwt_Test
{
    public class TokenAuthenticationService : IAuthenticateService
    {
        private readonly IUserService userService;
        private readonly TokenInfo tokenInfo;

        public TokenAuthenticationService(IUserService user_service, IOptions<TokenInfo> token_info)
        {
            this.userService = user_service;
            this.tokenInfo = token_info.Value;
        }

        public bool IsAuthenticated(LoginInfo loginInfo, out string token)
        {
            token = string.Empty;
            if (!userService.IsValid(loginInfo))
            {
                return false;
            }
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,loginInfo.userName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenInfo.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwtToken = new JwtSecurityToken(tokenInfo.Issuer, tokenInfo.Audience,claims, expires: DateTime.Now.AddMinutes(tokenInfo.AccessExpiration), signingCredentials: credentials);
            token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return true;
        }
    }
}

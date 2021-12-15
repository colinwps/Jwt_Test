using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jwt_Test
{
    public interface IAuthenticateService
    {
        bool IsAuthenticated(LoginInfo loginInfo, out string token);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jwt_Test
{
    public interface IUserService
    {
        bool IsValid(LoginInfo loginInfo);
    }
}

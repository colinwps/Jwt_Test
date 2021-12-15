using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jwt_Test
{
    public class UserService : IUserService
    {
        public bool IsValid(LoginInfo loginInfo)
        {
            return true;
        }
    }
}

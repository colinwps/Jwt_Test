using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Jwt_Test
{
    public class LoginInfo
    {
        [Required]
        [JsonProperty("username")]
        public string userName { get; set; }

        [Required]
        [JsonProperty("password")]
        public string password { get; set; }
    }
}

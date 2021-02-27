using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4Demo.Models
{
    public class LoginInput
    {
        public string ReturnUrl { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberLogin { get; set; }
        public bool AllowRememberLogin { get; set; }
    }
}

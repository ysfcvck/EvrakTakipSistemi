using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvrakTakipSistemi.Models.Authentication
{
    public class CustomIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DuplicateUserName(string userName) => new IdentityError { Code = "DuplicateUserName", Description = $"\"{ userName }\" kullanıcı adı kullanılmaktadır." };
        public override IdentityError InvalidUserName(string userName) => new IdentityError { Code = "InvalidUserName", Description = "Geçersiz kullanıcı adı." };
        public override IdentityError DuplicateEmail(string email) => new IdentityError { Code = "DuplicateEmail", Description = $"\"{ email }\" başka bir kullanıcı tarafından kullanılmaktadır." };
        public override IdentityError InvalidEmail(string email) => new IdentityError { Code = "InvalidEmail", Description = "Geçersiz email." };
    }
}

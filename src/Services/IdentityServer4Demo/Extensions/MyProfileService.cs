using IdentityServer4.Models;
using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServer4Demo.Extensions
{
    public class MyProfileService : IProfileService
    {
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            //获取IdentityServer给我们定义的Cliams和我们在SignAsync添加的Claims
            var claims = context.Subject.Claims.ToList();
            claims.Add(new System.Security.Claims.Claim(ClaimTypes.OtherPhone,"123456789"));

            context.IssuedClaims = claims;

            return Task.CompletedTask;
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.CompletedTask;
        }
    }
}

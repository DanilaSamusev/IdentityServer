using IdentityModel;
using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class PasswordGrantTypeValidator : IResourceOwnerPasswordValidator
    {
               
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            ClaimsIdentity userIdentity = new ClaimsIdentity();

            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            userIdentity.AddClaim(new Claim(JwtClaimTypes.Subject, "sub"));
            userIdentity.AddClaim(new Claim(JwtClaimTypes.IdentityProvider, "homekuru"));
            userIdentity.AddClaim(new Claim(JwtClaimTypes.AuthenticationMethod, "password"));
            userIdentity.AddClaim(new Claim(JwtClaimTypes.AuthenticationTime, ((long) (DateTime.UtcNow - epoch).TotalSeconds).ToString()));

            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

            var res = new GrantValidationResult(principal);

            context.Result = res;
        }
    }
}


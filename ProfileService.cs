using IdentityServer4.Models;
using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;

namespace IdentityServer
{
    public class ProfileService : IProfileService
    {
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var userIdentity = new ClaimsIdentity();

            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            userIdentity.AddClaim(new Claim(JwtClaimTypes.Subject, "1"));
            userIdentity.AddClaim(new Claim(JwtClaimTypes.IdentityProvider, "homekuru"));
            userIdentity.AddClaim(new Claim(JwtClaimTypes.AuthenticationMethod, "password"));
            userIdentity.AddClaim(new Claim(JwtClaimTypes.AuthenticationTime, (DateTime.UtcNow - epoch).TotalSeconds.ToString()));

            IEnumerable<Claim> requestedClaims =
                userIdentity.FindAll(p => context.RequestedClaimTypes.Contains(p.Type));

            context.AddRequestedClaims(requestedClaims);

            return null;
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;

            return Task.CompletedTask;
        }
    }
}
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public  class ClaimTransformationIdentity : IClaimsTransformation
    {
        private readonly IEnumerable<Claim>? _claims;
        private readonly Claim? _claim;
        public ClaimTransformationIdentity(IEnumerable<Claim> claims) => _claims = claims;
        public ClaimTransformationIdentity(Claim claim) => _claim = claim;

        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity();

            if (_claims !=null)
            {
                foreach (Claim claim in _claims)
                {
                    if (!principal.HasClaim(c => c.Type == claim.Type))
                    {
                        claimsIdentity.AddClaim(claim);
                    }
                }
            }

            if(_claim != null)
            {
                if (!principal.HasClaim(c => c.Type == _claim.Type))
                {
                    claimsIdentity.AddClaim(_claim);
                }
            }
            principal.AddIdentity(claimsIdentity);

            return Task.FromResult(principal);
        }
    }
}

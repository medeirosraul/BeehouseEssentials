using Beehouse.Essentials.Identity.Cache;
using Beehouse.Essentials.Identity.Claims;
using Beehouse.Essentials.Identity.Subscriptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;

namespace Beehouse.Essentials.Identity
{
    public static class IdentityIssuer
    {
        public static ClaimsIdentity IssueBeehouseIdentity(IdentityUserExtended user)
        {
            // Try get from cache
            var beehouseIdentity = IdentityIssuerCache.TryGetIdentity(user.Id);
            if (beehouseIdentity != null) return beehouseIdentity;

            beehouseIdentity = new ClaimsIdentity();

            beehouseIdentity.AddClaim(new Claim(BeehouseClaimTypes.Identification, user.Id));
            beehouseIdentity.AddClaim(new Claim(BeehouseClaimTypes.Name, user.UserName));

            IdentityIssuerCache.PostIdentity(beehouseIdentity);

            return beehouseIdentity;
        }

        public static void UpdateClaims(IdentityUserExtended user, List<Claim> claims)
        {
            var beehouseIdentity = IdentityIssuerCache.TryGetIdentity(user.Id);
            if (beehouseIdentity == null)
                beehouseIdentity = IssueBeehouseIdentity(user);

            beehouseIdentity.AddClaims(claims);
            IdentityIssuerCache.PostIdentity(beehouseIdentity);
        }
    }
}
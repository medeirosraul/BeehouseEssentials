using System;
using System.Collections.Generic;
using System.Security.Claims;
using Beehouse.Essentials.Identity.Claims;

namespace Beehouse.Essentials.Identity.Cache
{
    public static class IdentityIssuerCache
    {
        private static IDictionary<string, ClaimsIdentity> _identities;

        public static IDictionary<string, ClaimsIdentity> GetCache()
        {
            if (_identities != null) return _identities;
            return _identities = new Dictionary<string, ClaimsIdentity>();
        }

        public static ClaimsIdentity TryGetIdentity(string identification)
        {
            var success = GetCache().TryGetValue(identification, out var identity);
            if (success) return identity;
            return null;
        }

        public static void PostIdentity(ClaimsIdentity identity)
        {
            var identification = identity.FindFirst(BeehouseClaimTypes.Identification)?.Value;
            if (string.IsNullOrWhiteSpace(identification)) throw new UnauthorizedAccessException("IdentityIssuerCache >>>> Identity identification not found.");

            if (GetCache().ContainsKey(identification))
                GetCache().Remove(identification);

            GetCache().Add(identification, identity);
        }
    }
}

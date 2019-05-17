using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Beehouse.Essentials.Identity
{
    public class BeehouseClaimsPrincipalFactory:UserClaimsPrincipalFactory<IdentityUserExtended>
    {
        private IdentityUserExtended _user;
        private readonly UserManager<IdentityUserExtended> _userManager;
        public BeehouseClaimsPrincipalFactory(
            UserManager<IdentityUserExtended> userManager,
            IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
        {
            _userManager = userManager;
        }

        public override async Task<ClaimsPrincipal> CreateAsync(IdentityUserExtended user)
        {
            _user = await _userManager.Users
                .Include(p => p.Subscriptions)
                .FirstOrDefaultAsync(p => p.Id == user.Id);



            var beehouseIdentity = IdentityIssuer.IssueBeehouseIdentity(user);


            // Get base generated principal
            var principal = await base.CreateAsync(user);

            // Add identity
            principal.AddIdentity(beehouseIdentity);

            return principal;
        }
    }
}
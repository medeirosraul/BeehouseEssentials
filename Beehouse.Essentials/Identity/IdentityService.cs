using Beehouse.Essentials.Identity.Claims;
using Beehouse.Essentials.Identity.Subscriptions;
using Beehouse.Essentials.Identity.Subscriptions.Services;
using Beehouse.Essentials.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Beehouse.Essentials.Identity
{
    class IdentityService:IIdentityService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<IdentityUserExtended> _userManager;
        private readonly SignInManager<IdentityUserExtended> _signInManager;
        private readonly ISubscriptionService _subscriptionService;

        public IdentityService(IHttpContextAccessor httpContextAccessor, UserManager<IdentityUserExtended> userManager, SignInManager<IdentityUserExtended> signInManager, ISubscriptionService subscriptionService)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _signInManager = signInManager;
            _subscriptionService = subscriptionService;
        }

        public async Task<ICollection<Subscription>> GetSubscriptions()
        {
            var user = await GetIdentity();
            return user.Subscriptions;
        }

        public async Task SetSubscription(string subId)
        {
            var user = await GetIdentity();
            var sub = user.Subscriptions.FirstOrDefault(p => p.Id == subId);
            if (sub == null) throw new Exception("IdentityService >>>> Subscription not found.");

            // Generate claims from selected subscription
            var claims = GetSubscriptionClaims(sub);

            // Update issuer
            IdentityIssuer.UpdateClaims(user, claims);

            // Refresh signin
            await _signInManager.RefreshSignInAsync(user);
        }

        public async Task<IdentityUserExtended> GetIdentity()
        {
            var identification = _httpContextAccessor.HttpContext.User.FindFirst(BeehouseClaimTypes.Identification)?.Value;
            if (string.IsNullOrWhiteSpace(identification)) throw new UnauthorizedAccessException("IdentityService >>>> Identification not found.");

            var user = await _userManager.Users
                .Include(p => p.Subscriptions)
                .ThenInclude(p => p.Products)
                .FirstOrDefaultAsync(p => p.Id == identification);

            // Check if exist subscriptions. If not, create a basic subscription
            if (user.Subscriptions?.Any() != true)
                user.Subscriptions = new List<Subscription>(){ _subscriptionService.GetBasicSubscription(user) };
            

            return user;
        }

        private List<Claim> GetSubscriptionClaims(Subscription sub)
        {
            var claims = new List<Claim>
            {
                new Claim(BeehouseClaimTypes.SubscriptionId, sub.Id),
                new Claim(BeehouseClaimTypes.SubscriptionOwner, sub.OwnedBy)
            };

            foreach (var p in sub.Products)
            {
                claims.Add(new Claim(BeehouseClaimTypes.SubscriptionProduct, p.ProductName));
            }

            // Set claims in context Identity
            //((ClaimsIdentity)_httpContextAccessor.HttpContext.User.Identity).AddClaims(claims);

            return claims;
        }
    }
}
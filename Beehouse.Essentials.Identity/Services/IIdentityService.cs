using Beehouse.Essentials.Identity.Subscriptions;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Beehouse.Essentials.Identity
{
    public interface IIdentityService
    {
        Task<ICollection<Subscription>> GetSubscriptions();
        Task SetSubscription(string subId);
        Task<IdentityUserExtended> GetIdentity();
    }
}

using System.Collections;
using System.Collections.Generic;
using Beehouse.Essentials.Identity.Subscriptions;
using Microsoft.AspNetCore.Identity;

namespace Beehouse.Essentials.Identity
{
    public class IdentityUserExtended:IdentityUser
    {
        public ICollection<Subscription> Subscriptions { get; set; }
    }
}
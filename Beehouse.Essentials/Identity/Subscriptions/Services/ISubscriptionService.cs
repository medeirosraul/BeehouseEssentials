using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Beehouse.Essentials.Identity.Subscriptions.Services
{
    public interface ISubscriptionService
    {
        Subscription GetBasicSubscription(IdentityUserExtended user);
    }
}

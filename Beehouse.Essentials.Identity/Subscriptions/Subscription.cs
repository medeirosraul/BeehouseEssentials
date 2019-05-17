using System.Collections;
using System.Collections.Generic;
using Beehouse.Essentials.Identity.Entities;

namespace Beehouse.Essentials.Identity.Subscriptions
{
    public class Subscription:IndividualEntity
    {
        public string UserId { get; set; }
        public SubscriptionStatus Status { get; set; }
        public IEnumerable<SubscriptionProduct> Products { get; set; }
    }
}
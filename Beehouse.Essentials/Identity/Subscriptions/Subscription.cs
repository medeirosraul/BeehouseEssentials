using System.Collections;
using System.Collections.Generic;
using Beehouse.Essentials.Entities;

namespace Beehouse.Essentials.Identity.Subscriptions
{
    public class Subscription:UserEntity
    {
        public string UserId { get; set; }
        public SubscriptionStatus Status { get; set; }
        public IEnumerable<SubscriptionProduct> Products { get; set; }
    }
}
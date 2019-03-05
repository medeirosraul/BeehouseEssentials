using Beehouse.Essentials.Entities;

namespace Beehouse.Essentials.Identity.Subscriptions
{
    public class SubscriptionProduct:Entity
    {
        public string SubscriptionId { get; set; }
        public string ProductName { get; set; }
    }
}
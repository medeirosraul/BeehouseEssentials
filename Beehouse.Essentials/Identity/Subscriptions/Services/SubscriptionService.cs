using Beehouse.Essentials.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beehouse.Essentials.Identity.Subscriptions.Services
{
    public class SubscriptionService:ISubscriptionService
    {
        private readonly IService<Subscription> _subscriptionService;
        public SubscriptionService(IService<Subscription> subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        public Subscription GetBasicSubscription(IdentityUserExtended user)
        {
            var s = new Subscription
            {
                Id = "MAIN",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CreatedBy = user.Id,
                OwnedBy = user.Id,
                CreatorName = user.UserName,
                Deleted = false,
                UserId = user.Id,
                Status = SubscriptionStatus.Active,
                Products = new List<SubscriptionProduct>
                {
                    new SubscriptionProduct
                    {
                        Id = "MAIN",
                        CreatedAt = DateTime.Now,
                        Deleted = false,
                        ProductName = "Basic",
                        SubscriptionId = "MAIN",
                        UpdatedAt = DateTime.Now
                    }
                }
            };

            return s;
        }
    }
}

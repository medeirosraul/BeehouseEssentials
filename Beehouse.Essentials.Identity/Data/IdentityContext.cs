using Beehouse.Essentials.Identity;
using Beehouse.Essentials.Identity.Subscriptions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Beehouse.Essentials.Identity.Data
{
    public class IdentityContext:IdentityDbContext<IdentityUserExtended>
    {
        public IdentityContext(DbContextOptions options) : base(options)
        {
            // -- Constructor
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Identity");

            #region Identity

            builder.Entity<IdentityUserExtended>(o =>
            {
                o.HasMany(p => p.Subscriptions).WithOne().HasForeignKey(p => p.UserId);
            });

            builder.Entity<Subscription>(o =>
            {
                o.HasMany(p => p.Products).WithOne().HasForeignKey(p => p.SubscriptionId);
            });

            builder.Entity<SubscriptionProduct>(o => { o.Property(p => p.ProductName).IsRequired(); });

            #endregion
        }

    }
}
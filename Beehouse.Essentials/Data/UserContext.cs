using Beehouse.Essentials.Entities;
using Beehouse.Essentials.Identity;
using Beehouse.Essentials.Identity.Subscriptions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Beehouse.Essentials.Data
{
    public class UserContext: EntityContext
    {
        public UserContext(DbContextOptions options) : base(options)
        {
            // -- Constructor
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<UserEntity>();
        }
    }
}
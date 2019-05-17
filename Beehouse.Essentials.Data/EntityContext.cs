using Beehouse.Essentials.Entities;
using Microsoft.EntityFrameworkCore;

namespace Beehouse.Essentials.Data
{
    public class EntityContext:DbContext
    {
        public EntityContext(DbContextOptions<EntityContext> options) : base(options)
        {
            // -- Constructor
        }

        protected EntityContext(DbContextOptions options) : base(options)
        {
            // -- Constructor
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<Entity>();
        }
    }
}
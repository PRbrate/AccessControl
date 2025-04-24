using ControleDeAcesso.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace AccessControl.Data.Context
{
    class AccessControlContext : DbContext
    {
        public AccessControlContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<EventDomain> Event { get; set; }
        public DbSet<Participants> Participants { get; set; }
        public DbSet<UserEvent> UsersEvent { get; set; }


        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder
                .Properties<string>()
                .AreUnicode(false)
                .HaveMaxLength(100);

            configurationBuilder
                .Properties<float>()
                .HavePrecision(8, 2);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccessControlContext).Assembly);

            modelBuilder.

        }
}

using AccessControl.Core;
using AccessControl.Domain.Entites;
using ControleDeAcesso.Domain.Entites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AccessControl.Data.Context
{
    public class AccessControlContext : IdentityDbContext<User>
    {
        public AccessControlContext(DbContextOptions<AccessControlContext> options) : base(options)
        {
        }

        public DbSet<EventDomain> Event { get; set; }
        public DbSet<Participants> Participants { get; set; }
        public DbSet<UserEvent> UsersEvent { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }



        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder
                .Properties<string>()
                .AreUnicode(false)
                .HaveMaxLength(100);

            configurationBuilder
                .Properties<decimal>()
                .HavePrecision(8, 2);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccessControlContext).Assembly);

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {


            const string dataCadastro = "CreatedAt";
            const string contaId = "ContaId";

            foreach (var entry in ChangeTracker.Entries())
            {
                // Verifica se a entidade tem a propriedade 'CreatedAt'
                if (entry.Entity.GetType().GetProperty(dataCadastro) != null)
                {
                    if (entry.State == EntityState.Added)
                    {
                        // Define o valor atual para 'DataCadastro' com a hora do fuso horário
                        entry.Property(dataCadastro).CurrentValue = DateTime.UtcNow.HorasTimeZone();
                    }
                    else if (entry.State == EntityState.Modified)
                    {
                        // Impede a modificação de 'DataCadastro' durante o update
                        entry.Property(dataCadastro).IsModified = false;
                    }
                }

                // Verifica se a entidade tem a propriedade 'ContaId' e impede a modificação durante o update
                if (entry.Entity.GetType().GetProperty(contaId) != null && entry.State == EntityState.Modified)
                {
                    entry.Property(contaId).IsModified = false;
                }

            }
            return base.SaveChangesAsync(cancellationToken);

        }
    }
}
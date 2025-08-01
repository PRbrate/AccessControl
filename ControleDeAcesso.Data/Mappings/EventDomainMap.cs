using AccessControl.Core;
using ControleDeAcesso.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccessControl.Data.Mappings
{
    public class EventDomainMap : IEntityTypeConfiguration<EventDomain>
    {

        public void Configure(EntityTypeBuilder<EventDomain> builder)
        {
            builder.ToTable("Events");
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.HasIndex(e => e.ContaId);
            builder.HasIndex(e => e.UserId);
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Status)
           .HasConversion(
                          v => v.ToString(),
                          v => (Status)Enum.Parse(typeof(Status), v)
                          )
           .IsUnicode(false)
           .HasMaxLength(50);

        }
    }
}

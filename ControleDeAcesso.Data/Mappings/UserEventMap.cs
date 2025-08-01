using AccessControl.Core;
using ControleDeAcesso.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace AccessControl.Data.Mappings
{
    public class UserEventMap : IEntityTypeConfiguration<UserEvent>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserEvent> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Email)
                .IsRequired(true)
                .HasMaxLength(50)
                .IsUnicode(true);

            builder.Property(e => e.Password)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.HasIndex(e => e.ContaId);
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

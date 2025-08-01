using AccessControl.Core;
using AccessControl.Domain.Entites;
using AccessControl.Domain.Entites.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccessControl.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(c => c.ContaId);

            builder.HasKey(u => u.Id);

            builder.HasMany(u => u.Events)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .IsRequired();

            builder.Property(e => e.Status)
           .HasConversion(
                          v => v.ToString(),
                          v => (Status)Enum.Parse(typeof(Status), v)
                          )
           .IsUnicode(false)
           .HasMaxLength(50);

            builder.Property(e => e.UserType)
           .HasConversion(
                          v => v.ToString(),
                          v => (UserType)Enum.Parse(typeof(UserType), v)
                          )
           .IsUnicode(false)
           .HasMaxLength(50);


        }
    }
}

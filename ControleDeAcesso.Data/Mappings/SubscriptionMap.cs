using AccessControl.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.Data.Mappings
{
    public class SubscriptionMap : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Subscription> builder)
        {
            builder.ToTable("Subscriptions");
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Status)
                .IsRequired();
            builder.Property(s => s.PriceId)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(s => s.UserId)
                .IsRequired()
                .HasMaxLength(100);
            builder.HasOne(s => s.User)
                .WithMany()
                .HasForeignKey(s => s.UserId);
        }
    }
}

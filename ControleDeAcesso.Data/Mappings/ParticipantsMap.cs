using AccessControl.Core.Entities;
using ControleDeAcesso.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.Data.Mappings
{
    public class ParticipantsMap : IEntityTypeConfiguration<Participants>
    {
        public void Configure(EntityTypeBuilder<Participants> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.HasIndex(e => e.ContaId);
            builder.HasKey(e => e.Id);

            builder.HasOne(p => p.UserEvent)
                .WithMany(u => u.Participants)
                .HasForeignKey(p => p.UserId)
                .IsRequired();


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

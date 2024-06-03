using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    internal class ProfessorConfiguration: IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.ToTable("professors");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .HasColumnName("id");

            builder.Property(s => s.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(s => s.LastName)
                .HasColumnName("last_name")
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(s => s.Gender)
                 .HasColumnName("gender")
                .IsRequired()
                .HasMaxLength(1);

            /*builder
              .HasMany(g => g.Grade)
              .WithOne(p => p.Professor)
              .IsRequired(false);*/
        }
    }
}

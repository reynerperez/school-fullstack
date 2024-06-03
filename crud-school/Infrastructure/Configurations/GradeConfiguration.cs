using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    internal class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.ToTable("grades");

            builder.HasKey(g => g.Id);

            builder.Property(g => g.Id)
                .HasColumnName("id");

            builder.Property(g => g.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(250);

            builder
                .HasOne(g => g.Professor)
                .WithMany(p => p.Grades)
                .HasForeignKey("professor_id");
        }
    }
}

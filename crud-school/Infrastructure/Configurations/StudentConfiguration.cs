using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("students");

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

            builder.Property(s => s.BirthDate)
                .HasColumnName("birth_date")
                .IsRequired();

            /*builder.HasMany(s => s.Grades)
                .WithMany(g => g.Students)
                .UsingEntity(
                    "student_grade",
                    g => g.HasOne(typeof(Grade)).WithMany().HasForeignKey("grade_id").HasPrincipalKey(nameof(Grade.Id)),
                    s => s.HasOne(typeof(Student)).WithMany().HasForeignKey("student_id").HasPrincipalKey(nameof(Student.Id)),
                    s => s.HasKey("student_id", "grade_id"));*/

        }
    }
}

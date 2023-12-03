using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Percistency.Data.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Course");

            builder.Property(p=>p.Title).HasColumnName("Title").HasMaxLength(150).IsRequired();
            builder.Property(p=>p.Description).HasColumnName("Description").HasMaxLength(300).IsRequired();
            builder.HasOne(p=>p.Instructor).WithMany(p=>p.Courses).HasForeignKey(p=>p.InstructorId);
            builder.Property(p=>p.AverageRating).HasColumnName("AverageRating").HasColumnType("float").IsRequired();
            builder.HasOne(p=>p.CourseImage).WithMany(p=>p.Courses).HasForeignKey(p=>p.CourseImageId);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Percistency.Data.Configurations
{
    public class CourseImageConfiguration : IEntityTypeConfiguration<CourseImage>
    {
        public void Configure(EntityTypeBuilder<CourseImage> builder)
        {
            builder.ToTable("CourseImage");

            builder.Property(p=>p.Image).HasColumnName("Image").HasColumnType("varbinary(MAX)").IsRequired();
            builder.Property(p=>p.UploadDate).HasColumnName("UploadDate").HasColumnType("datetime").IsRequired();
            builder.HasOne(i=>i.Course).WithOne(i=>i.CourseImage).HasForeignKey<CourseImage>(i=>i.CourseId).IsRequired(false);
        }
    }
}
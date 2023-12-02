using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Percistency.Data.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comment");

            builder.Property(p=>p.CourseComment).HasColumnName("CourseComment").HasMaxLength(1000).IsRequired();
            builder.HasOne(p=>p.User).WithMany(p=>p.Comments).HasForeignKey(p=>p.UserId);
            builder.HasOne(p=>p.Course).WithMany(p=>p.Comments).HasForeignKey(p=>p.CourseId);
        }
    }
}
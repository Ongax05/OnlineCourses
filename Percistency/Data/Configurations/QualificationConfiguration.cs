using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Percistency.Data.Configurations
{
    public class QualificationConfiguration : IEntityTypeConfiguration<Qualification>
    {
        public void Configure(EntityTypeBuilder<Qualification> builder)
        {
            builder.ToTable("Qualidication",t=>t.HasCheckConstraint("CK_Qualification_CourseQualification", "[CourseQualification] >= 1 AND [CourseQualification] <= 5"));

            builder
                .Property(p => p.CourseQualification)
                .HasColumnName("CourseQualification")
                .HasColumnType("float")
                .IsRequired();

            builder
                .HasOne(p => p.User)
                .WithMany(p => p.Qualifications)
                .HasForeignKey(p => p.UserId);
            builder
                .HasOne(p => p.Course)
                .WithMany(p => p.Qualifications)
                .HasForeignKey(p => p.CourseId);
        }
    }
}

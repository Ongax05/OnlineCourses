using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.Property(p => p.Id).IsRequired();

        builder
            .Property(p => p.Username)
            .HasColumnName("username")
            .HasColumnType("varchar")
            .HasMaxLength(50);

        builder
            .Property(p => p.Password)
            .HasColumnName("password")
            .HasColumnType("varchar")
            .HasMaxLength(255)
            .IsRequired();

        builder
            .Property(p => p.Email)
            .HasColumnName("email")
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

        builder
            .HasMany(p => p.Roles)
            .WithMany(r => r.Users)
            .UsingEntity<UserRol>(
                j =>
                    j.HasOne(pt => pt.Rol)
                        .WithMany(t => t.UsersRoles)
                        .HasForeignKey(ut => ut.RolId),
                j =>
                    j.HasOne(et => et.User)
                        .WithMany(et => et.UsersRoles)
                        .HasForeignKey(el => el.UserId),
                j =>
                {
                    j.ToTable("userRol");
                    j.HasKey(t => new { t.UserId, t.RolId });
                }
            );

        builder.HasMany(p => p.RefreshTokens).WithOne(p => p.User).HasForeignKey(p => p.UserId);
        builder.HasOne(i=>i.Instructor).WithOne(i=>i.User).HasForeignKey<Instructor>(i=>i.UserId).IsRequired(false);
    }
}

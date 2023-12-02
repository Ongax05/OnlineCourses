using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
namespace Domain.Entities;

public class User : BaseEntity
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    #nullable enable
    public int? InstructorId { get; set; }
    public Instructor? Instructor { get; set; }
    #nullable disable
    public ICollection<Rol> Roles { get; set; } = new HashSet<Rol>();
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new HashSet<RefreshToken>();
    public ICollection<UserRol> UsersRoles { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<Qualification> Qualifications { get; set; }
}

namespace API.Helpers;

public class Authorization
{
    public enum Roles
    {
        User,
        Instructor
    }

    public const Roles rol_default = Roles.User;
}

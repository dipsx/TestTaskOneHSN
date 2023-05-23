using DotNetCore.Domain;

namespace TestTask.Domain;

public class User : Entity {

    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;

    public Roles Roles { get; set; } = Roles.None;

}


using DotNetCore.Domain;

namespace TestTask.Domain;
public class Auth : Entity {
    public string Login { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public Guid Salt { get; set; }
    public Roles Roles { get; set; }

    public long UserId { get; set; }
    public User? User { get; set; }
}

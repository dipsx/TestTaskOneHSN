using DotNetCore.Domain;

namespace TestTask.Domain;

public class User : Entity {
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;

}


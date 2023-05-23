using FluentValidation;

namespace TestTask.App.User;

public sealed class AuthRequestValidator : AbstractValidator<AuthRequest> {
    public AuthRequestValidator() {
        RuleFor(request => request.Email).Email();
        RuleFor(request => request.Password).Password();
    }
}

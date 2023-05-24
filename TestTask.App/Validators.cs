
using FluentValidation;

namespace TestTask.App;

public static class Validators {
    public static IRuleBuilderOptions<T, string> Email<T>(this IRuleBuilder<T, string> builder) => builder.NotEmpty().EmailAddress();
    public static IRuleBuilderOptions<T, string> Login<T>(this IRuleBuilder<T, string> builder) => builder.NotEmpty();
    public static IRuleBuilderOptions<T, string> Password<T>(this IRuleBuilder<T, string> builder) => builder.NotEmpty();
}

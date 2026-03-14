namespace ERPLite.Users.Application.UseCases.RegisterUser
{
    using FluentValidation;

    public class RegisterUserValidator : AbstractValidator<RegisterUserRequest>
    {
        public RegisterUserValidator()
        {
            _ = this.RuleFor(x => x.Name)
                    .NotEmpty()
                    .MinimumLength(2)
                    .MaximumLength(200);
            _ = this.RuleFor(x => x.Email)
                    .NotEmpty()
                    .EmailAddress()
                    .MinimumLength(5)
                    .MaximumLength(500);
            _ = this.RuleFor(x => x.Username)
                    .NotEmpty()
                    .MinimumLength(5)
                    .MaximumLength(50);
            _ = this.RuleFor(x => x.Password)
                    .NotEmpty()
                    .MinimumLength(8)
                    .MaximumLength(128)
                    .Matches("[a-z]{1}")
                    .Matches("[A-Z]{1}")
                    .Matches("[0-9]{1}")
                    .Matches("\\w{1}");
            _ = this.RuleFor(x => x.ConfirmPassword)
                    .Equal(x => x.Password);
        }
    }
}

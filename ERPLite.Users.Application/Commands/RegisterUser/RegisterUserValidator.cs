namespace ERPLite.Users.Application.Commans.RegisterUser
{
    using ERPLite.Users.Domain.Interfaces;
    using ERPLite.Users.Domain.Results;

    using System.Threading.Tasks;

    public class RegisterUserValidator(IValidationMessageProvider validationMessageProvider) : IValidator<RegisterUserRequest>
    {
        private readonly IValidationMessageProvider validationMessageProvider = validationMessageProvider;

        public Task<ValidationResult> ValidateAsync(RegisterUserRequest model)
        {
            var validationResult = new ValidationResult();


            return Task.FromResult(validationResult);
        }
    }
}

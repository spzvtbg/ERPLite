namespace ERPLite.Users.Application.Commans.RegisterUser
{
    using ERPLite.Users.Domain.Interfaces;
    using ERPLite.Users.Domain.Results;

    using System.Threading.Tasks;

    public class RegisterUserValidator(IResourceProvider resourceProvider) : IValidator<RegisterUserRequest>
    {
        private readonly IResourceProvider resourceProvider = resourceProvider;

        public async Task<ValidationResult> ValidateAsync(RegisterUserRequest model)
        {
            var validationResult = new ValidationResult();

            if (model == null)
            {
                validationResult.IsValid = false;
                validationResult.ErrorMessage = await this.resourceProvider
                    .MessageForAsync("en", $"{nameof(RegisterUserRequest)}CannotBeNull");
            }


            return validationResult;
        }
    }
}

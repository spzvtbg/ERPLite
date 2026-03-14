namespace ERPLite.Users.Application.UseCases.RegisterUser
{
    using FluentValidation;

    using System.Threading.Tasks;

    public class RegisterUserHandler(IValidator<RegisterUserRequest> validator)
    {
        private readonly IValidator<RegisterUserRequest> validator = validator;
        // TODO: inject IMapper
        // TODO: inject UserManager

        public async Task<RegisterUserResponse> HandleAsync(RegisterUserRequest request)
        {
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                return new RegisterUserFailedResponse();
            }

            // TODO: map request to User entity
            // TODO: create user account

            return new RegisterUserResponse();
        }
    }
}

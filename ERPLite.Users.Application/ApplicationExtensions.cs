namespace ERPLite.Users.Application
{
    using ERPLite.Users.Application.UseCases.RegisterUser;

    using FluentValidation;

    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            _ = services
                .AddValidatorsFromAssembly(typeof(ApplicationExtensions).Assembly)
                .AddTransient<RegisterUserHandler>();

            return services;
        }
    }
}

namespace ERPLite.Users.Application
{
    using ERPLite.Users.Application.Commans.RegisterUser;
    using ERPLite.Users.Domain.Interfaces;
    using ERPLite.Users.Infrastructure;

    using Microsoft.Extensions.DependencyInjection;

    using System.Linq;

    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            _ = services
                .AddValidators()
                .AddTransient<IValidationMessageProvider, DbValidationMessageProvider>()
                .AddTransient<RegisterUserHandler>();

            return services;
        }

        private static IServiceCollection AddValidators(this IServiceCollection services)
        {
            var types = typeof(ApplicationExtensions).Assembly.GetTypes();

            foreach (var type in typeof(ApplicationExtensions).Assembly.GetTypes())
            {
                foreach (var abstraction in type.GetInterfaces())
                {
                    if (abstraction.IsGenericType && abstraction.GetGenericTypeDefinition() == typeof(IValidator<>))
                    {
                        _ = services.AddTransient(abstraction, type);
                    }
                }
            }

            return services;
        }
    }
}

namespace ERPLite.Users
{
    using ERPLite.Users.Application;
    using ERPLite.Users.Infrastructure;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            var services = builder.Services;
            _ = services.AddDbContext<UsersDbContext>(options =>
            { 
                var connectionString = configuration.GetConnectionString("ERPLiteUsers");

                _ = options
                    .UseSqlServer(connectionString)
                    .EnableDetailedErrors()
                    .EnableSensitiveDataLogging()
                    .EnableServiceProviderCaching()
                    .EnableThreadSafetyChecks();
            });

            _ = services
                .AddApplication()
                .AddControllers();


            var app = builder.Build();
            _ = app.MapControllers();   

            app.Run();
        }
    }
}

namespace ERPLite.Users.Infrastructure
{
    using ERPLite.Users.Domain.Entities;
    using ERPLite.Users.Infrastructure.EntityTypeConfigurations;

    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Represents the database context for the Users module, 
    /// providing access to the Users table and configuring the entity mappings.
    /// </summary>
    public class UsersDbContext(DbContextOptions options) : DbContext(options)
    {
        /// <summary>
        /// Users table in the database, representing the collection of user entities.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Users table in the database, representing the collection of user entities.
        /// </summary>
        public DbSet<Role> Roels { get; set; }

        /// <summary>
        /// Resources table in the database, representing the collection of resource entities.
        /// </summary>
        public DbSet<Resource> Resources { get; set; }

        /// <summary>
        /// Fallback configuration method that will be called if the context is not configured externally.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // If the context is not configured, we set up a fallback connection string to a local SQL Server instance.
                var fallbackConnectionStringBuilder = new SqlConnectionStringBuilder
                {
                    DataSource = ".",
                    InitialCatalog = "ERPLiteUsers",
                    Encrypt = false,
                    TrustServerCertificate = true,
                    IntegratedSecurity = true,
                    MultipleActiveResultSets = true,
                };
                // Build the connection string from the builder and configure the context to use SQL Server with this connection string,
                var fallbackConnectionString = fallbackConnectionStringBuilder.ToString();

                _ = optionsBuilder
                    // Configure the context to use SQL Server with the fallback connection string
                    .UseSqlServer(fallbackConnectionString)
                    // Enable detailed errors for better debugging and diagnostics.
                    .EnableDetailedErrors()
                    // Enable sensitive data logging to include potentially sensitive information in logs for debugging purposes.
                    .EnableSensitiveDataLogging()
                    // Enable caching of the service provider to improve performance by reusing the same service provider instance.
                    .EnableServiceProviderCaching()
                    // Enable thread safety checks to ensure that the context is used in a thread-safe manner, preventing potential issues in multi-threaded scenarios.
                    .EnableThreadSafetyChecks();
            }
        }

        /// <summary>
        /// Will be called by the framework to configure the database context, applying entity configurations.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder
                // Apply the entity type configurations for the Users entity, defining how they map to the database schema.
                .ApplyConfiguration(new UsersEntityTypeConfiguration())
                // Apply the entity type configurations for the Roles entity, defining how they map to the database schema.
                .ApplyConfiguration(new RolesEntityTypeConfiguration())
                // Apply the entity type configurations for the Resource entity, defining how they map to the database schema.
                .ApplyConfiguration(new ResourceEntityTypeConfiguration());
    }
}
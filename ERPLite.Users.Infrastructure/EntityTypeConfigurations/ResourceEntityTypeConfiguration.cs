namespace ERPLite.Users.Infrastructure.EntityTypeConfigurations
{
    using ERPLite.Users.Domain.Entities;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Configures the Resource entity for Entity Framework Core, 
    /// defining how the Resource class maps to the database schema, 
    /// including property configurations, primary key, unique indexes, 
    /// and check constraints to ensure data integrity and enforce business rules.
    /// </summary>
    public class ResourceEntityTypeConfiguration : IEntityTypeConfiguration<Resource>
    {
        /// <summary>
        /// Used by Entity Framework Core to apply the configuration for the Resource entity.
        /// </summary>
        /// <param name="resource"></param>
        public void Configure(EntityTypeBuilder<Resource> resource)
        {
            // Configure the properties of the Resource entity to define how they are mapped to the database columns.
            _ = resource
                // The Id property configuration.
                .Property(x => x.Id)
                // Whit identity 1,1
                .ValueGeneratedOnAdd()
                // Is required, meaning that it cannot be null in the database, ensuring that every resource has a unique identifier.
                .IsRequired();

            _ = resource
                // The Lang property configuration.
                .Property(x => x.Lang)
                // Is required, meaning that it cannot be null in the database, ensuring that every resource has a unique identifier.
                .IsRequired()
                // The Lang property is configured to have a maximum length of 10 characters,
                // which is sufficient for standard language codes (e.g., "en", "fr", "es") while also preventing
                // excessively long values that could lead to data integrity issues.
                .HasMaxLength(10);

            _ = resource
                // The Name property configuration.
                .Property(x => x.Name)
                // Is required, meaning that it cannot be null in the database, ensuring that every resource has a unique identifier.
                .IsRequired()
                // The Name property is configured to have a maximum length of 200 characters,
                // which allows for descriptive resource names while also preventing
                // excessively long values that could lead to data integrity issues.
                .HasMaxLength(200);

            _ = resource
                // The Content property configuration.
                .Property(x => x.Content)
                // Is required, meaning that it cannot be null in the database, ensuring that every resource has a unique identifier.
                .IsRequired()
                // The Content property is configured to be stored as Unicode text in the database,
                .IsUnicode()
                // and it is set to have a maximum length of NVARCHAR(MAX),
                // allowing for large amounts of text content to be stored without a predefined limit.
                // May contain large texts, image data, or other types of content that require a flexible storage solution.
                .HasColumnType("NVARCHAR(MAX)");

            // Define the primary key and unique index to ensure data integrity and optimize query performance.
            _ = resource
                // The Id property serves as the primary key, uniquely identifying each resource in the database.
                .HasKey(x => x.Id)
                // The primary key constraint is named "PK_Resources_Id" for clarity and consistency in the database schema.
                .HasName("PK_Resources_Id");
            _ = resource
                // A unique index is created on the combination of Lang and Name to ensure that each resource is
                // uniquely identifiable by its language and name.
                .HasIndex(x => new { x.Lang, x.Name }, "UQ_Resources_Lang_Name")
                // The unique index constraint is named "UQ_Resources_Lang_Name" to clearly indicate its purpose
                // and the columns it applies to.
                .IsUnique();

            // Add check constraints to ensure data integrity and enforce business rules.
            _ = resource.ToTable(x =>
            {
                // The Lang property must be at least 1 character long to ensure valid language codes.
                _ = x.HasCheckConstraint("CK_Resources_Lang", "LEN(Lang) >= 2");

                // The Name property must be at least 2 characters long to ensure meaningful resource names.
                _ = x.HasCheckConstraint("CK_Resources_Name", "LEN(Name) >= 2");
            });
        }
    }
}

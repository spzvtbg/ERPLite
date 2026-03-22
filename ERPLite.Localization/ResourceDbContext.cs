namespace ERPLite.Localization
{
    using Microsoft.EntityFrameworkCore;

    internal class ResourceDbContext : DbContext
    {
        public DbSet<Resource> Resources { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var resource = modelBuilder.Entity<Resource>();

            _ = resource
                .Property(r => r.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(1, 1)
                .IsRequired();

            _ = resource
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(256);

            _ = resource
                .Property(r => r.Lang)
                .IsRequired()
                .HasMaxLength(16);

            _ = resource
                .Property(r => r.Value)
                .IsRequired()
                .HasColumnType("NVARCHAR(MAX)");

            _ = resource
                .HasKey(x => x.Id)
                .HasName("PK_Resources_Id");

            _ = resource
                .HasIndex(x => new { x.Name, x.Lang })
                .IsUnique()
                .HasDatabaseName("IX_Resources_Name_Lang");

            _ = resource.ToTable(resources =>
            { 
                _ = resources.HasCheckConstraint("CK_Resources_Name_MinLen", "LEN(Name) >= 2");
                _ = resources.HasCheckConstraint("CK_Resources_Lang_MinLen", "LEN(Lang) >= 2");
                _ = resources.HasCheckConstraint("CK_Resources_Value_MinLen", "LEN(Value) >= 2");
            });
        }
    }
}

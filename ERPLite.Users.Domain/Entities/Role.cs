namespace ERPLite.Users.Domain.Entities
{
    using System;

    /// <summary>
    /// Represents a role within the system, defining a set of permissions or access rights that can be assigned to users.
    /// </summary>
    public class Role
    {
        /// <summary>
        /// Gets or sets the unique identifier for the role, which serves as the primary key in the database.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the role, which is a human-readable identifier that describes the role's purpose or function within the system.
        /// </summary>
        public string Name { get; set; }
    }
}

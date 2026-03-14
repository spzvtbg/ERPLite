namespace ERPLite.Users.Domain.Entities
{
    using System;

    /// <summary>
    /// Represents a user within the system, containing properties such as Id, Name, Email, Username, and Password.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user, which serves as the primary key in the database.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the user, which is a human-readable identifier that 
        /// describes the user's identity within the system.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user, which is used for communication and 
        /// may also serve as a unique identifier for authentication purposes.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the username of the user, which is a unique identifier used for 
        /// authentication and login purposes within the system.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password of the user, which is used for authentication purposes.
        /// </summary>
        public string Password { get; set; }
    }
}

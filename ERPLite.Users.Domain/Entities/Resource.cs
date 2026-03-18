namespace ERPLite.Users.Domain.Entities
{
    /// <summary>
    /// The Resource class represents a localized resource entity that contains information about a specific resource,
    /// </summary>
    public class Resource
    {
        /// <summary>
        /// The Id property is the unique identifier for the resource, typically used as the primary key in a database.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The Lang property represents the language code for the resource, 
        /// indicating the language in which the resource content is written (e.g., "en" for English, "fr" for French).
        /// </summary>
        public string Lang { get; set; }

        /// <summary>
        /// The Name property represents the name or key of the resource, which is used to identify the specific resource content.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Content property contains the actual content of the resource, which can be a localized message, description, 
        /// or any other type of data that needs to be stored and retrieved based on the language and name of the resource.
        /// </summary>
        public string Content { get; set; }
    }
}

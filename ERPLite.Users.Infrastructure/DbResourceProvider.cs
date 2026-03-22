namespace ERPLite.Users.Infrastructure
{
    using ERPLite.Users.Domain.Entities;
    using ERPLite.Users.Domain.Interfaces;

    using System.Threading.Tasks;

    /// <summary>
    /// Resourse provider that uses the database as source. 
    /// </summary>
    /// <param name="usersDbContext"></param>
    public class DbResourceProvider(UsersDbContext usersDbContext) : IResourceProvider
    {
        private readonly UsersDbContext usersDbContext = usersDbContext;

        /// <summary>
        /// Gets the message content for the specified language and name. 
        /// If the message does not exist, it will be created with a default content and returned.
        /// </summary>
        /// <param name="lang"><see cref="System.String"/></param>
        /// <param name="name"><see cref="System.String"/></param>
        /// <returns>The resource value.</returns>
        public async Task<string> MessageForAsync(string lang, string name)
        {
            if (string.IsNullOrWhiteSpace(lang))
            {
                lang = "en";
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                name = "undefined";
            }

            var resource = await this.usersDbContext.FindAsync<Resource>(lang, name);

            if (resource is null)
            {
                var entityEntry = await this.usersDbContext.AddAsync(new Resource
                { 
                    Lang = lang,
                    Name = name,
                    Content = $"*{name}"
                });
                var rowsAffected = await this.usersDbContext.SaveChangesAsync();

                if (rowsAffected == 1)
                {
                    resource = entityEntry.Entity;
                }
            }

            return resource?.Content ?? $"<{name}";
        }
    }
}

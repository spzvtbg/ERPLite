namespace ERPLite.Users.Infrastructure
{
    using ERPLite.Users.Domain.Entities;
    using ERPLite.Users.Domain.Interfaces;

    using System.Threading.Tasks;

    public class DbValidationMessageProvider(UsersDbContext usersDbContext) : IValidationMessageProvider
    {
        private readonly UsersDbContext usersDbContext = usersDbContext;

        public async Task<string> MessageForAsync(string lang, string name)
        {
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

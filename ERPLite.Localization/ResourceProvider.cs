namespace ERPLite.Localization
{
    using ERPLite.Localization.Contracts;

    using System.Collections.Generic;
    using System.Linq;

    internal class ResourceProvider(ResourceDbContext resourceDbContext) : IResourceProvider
    {
        private readonly ResourceDbContext resourceDbContext = resourceDbContext;

        public IReadOnlyDictionary<string, string> GetAllStrings(string lang) 
            => this.resourceDbContext
                .Resources
                .Select(x => new KeyValuePair<string, string>(x.Name, x.Value))
                .ToDictionary(x => x.Key, x => x.Value);

        public string GetFormatedString(string name, string lang, object[] args)
        {
            var value = this.GetString(name, lang);

            return string.Format(value, args);
        }

        public string GetString(string name, string lang)
        {
            var resource = this
                .resourceDbContext
                .Resources
                .Find(name, lang);

            if (resource is null)
            {
                resource = new Resource
                {
                    Name = name,
                    Lang = lang,
                    Value = $"*{name}"
                };

                _ = this.resourceDbContext.Add(resource);
                _ = this.resourceDbContext.SaveChanges();
            }
            
            return resource.Value;
        }
    }
}

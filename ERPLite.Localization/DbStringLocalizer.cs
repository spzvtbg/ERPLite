namespace ERPLite.Localization
{
    using ERPLite.Localization.Contracts;

    using Microsoft.Extensions.Localization;

    public class DbStringLocalizer(IResourceProvider resourceProvider) : IStringLocalizer
    {
        private readonly IResourceProvider resourceProvider = resourceProvider;

        public LocalizedString this[string name]
        {
            get
            {
                var value = this.resourceProvider.GetString(name);

                return new LocalizedString(name, value ?? $"*{name}");
            }
        }

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                var value = this.resourceProvider.GetFormatedString(name, arguments);

                return new LocalizedString(name, value ?? $"*{name}");
            }
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures) 
            => this.resourceProvider
                .GetAllStrings()
                .Select(x => new LocalizedString(x.Key, x.Value ?? $"*{x.Key}"));
    }
}

namespace ERPLite.Localization
{
    using ERPLite.Localization.Contracts;

    using Microsoft.Extensions.Localization;

    public class DbStringLocalizerFactory(IResourceProvider resourceProvider) : IStringLocalizerFactory
    {
        private readonly IResourceProvider resourceProvider = resourceProvider;

        public IStringLocalizer Create(Type _)
            => new DbStringLocalizer(this.resourceProvider);

        public IStringLocalizer Create(string _, string _1)
            => new DbStringLocalizer(this.resourceProvider);
    }
}

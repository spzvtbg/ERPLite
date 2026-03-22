namespace ERPLite.Localization.Contracts
{
    using System.Collections.Generic;

    public interface IResourceProvider
    {
        IReadOnlyDictionary<string, string> GetAllStrings(string lang);

        string GetFormatedString(string name, string lang, object[] args);

        string GetString(string name, string lang);
    }
}
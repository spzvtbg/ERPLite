namespace ERPLite.Users.Domain.Interfaces
{ 
    using System.Threading.Tasks;

    /// <summary>
    /// Provides validation messages for the application. 
    /// This interface defines a contract for retrieving validation messages based on language and message name.
    /// </summary>
    public interface IValidationMessageProvider
    {
        /// <summary>
        /// Gets or adds a validation message for the specified language and message name.
        /// </summary>
        /// <param name="lang"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<string> MessageForAsync(string lang, string name);
    }
}

namespace ERPLite.Users.Domain.Interfaces
{
    using ERPLite.Users.Domain.Results;

    using System.Threading.Tasks;

    /// <summary>
    /// Validator interface for validating models of type T. 
    /// Implementations of this interface should provide logic to validate the given model and 
    /// return a ValidationResult indicating the success or failure of the validation process.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IValidator<T>
    {
        /// <summary>
        /// Asynchronously validates the provided model of type T.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>ValidationResult indicating the success or failure of the validation process.</returns>
        Task<ValidationResult> ValidateAsync(T model);
    }
}

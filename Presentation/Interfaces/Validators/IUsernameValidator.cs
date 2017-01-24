namespace NullReferencesDemo.Presentation.Interfaces.Validators
{
    public interface IUsernameValidator : IValidator
    {
        bool IsValid(string username);
        int MinLength { get; }
    }
}

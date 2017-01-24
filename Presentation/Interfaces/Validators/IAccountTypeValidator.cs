namespace NullReferencesDemo.Presentation.Interfaces.Validators
{
    public interface IAccountTypeValidator : IValidator
    {
        bool IsValid(char accountTypeId);
    }
}

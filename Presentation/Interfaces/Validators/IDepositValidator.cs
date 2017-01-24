namespace NullReferencesDemo.Presentation.Interfaces.Validators
{
    public interface IDepositValidator : IValidator
    {
        bool IsValid(string amount);
    }
}

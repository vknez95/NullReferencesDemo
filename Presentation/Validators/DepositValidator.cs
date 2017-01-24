using NullReferencesDemo.Presentation.Interfaces.Validators;

namespace NullReferencesDemo.Presentation.Validators
{
    public class DepositValidator : IDepositValidator
    {
        public bool IsValid(string amount)
        {
            decimal decAmount = 0;

            decimal.TryParse(amount, out decAmount);

            return decAmount > 0;
        }
    }
}

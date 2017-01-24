using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Implementation.CommandResults
{
    public class InvalidAccountType : ICommandResult
    {
        public char AccountTypeId { get; }

        public InvalidAccountType(char accountTypeId)
        {
            this.AccountTypeId = accountTypeId;
        }
    }
}

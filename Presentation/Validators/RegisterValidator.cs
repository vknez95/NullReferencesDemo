using NullReferencesDemo.Presentation.Interfaces.Validators;

namespace NullReferencesDemo.Presentation.Validators
{
    public class RegisterValidator : IRegisterValidator
    {
        private readonly IUsernameValidator usernameValidator;
        private readonly IAccountTypeValidator accountTypeValidator;

        public RegisterValidator(IUsernameValidator usernameValidator, IAccountTypeValidator accountTypeValidator)
        {
            this.usernameValidator = usernameValidator;
            this.accountTypeValidator = accountTypeValidator;
        }

        public int MinLength
        {
            get
            {
                return this.usernameValidator.MinLength;
            }
        }

        public bool IsValid(char accountTypeId)
        {
            return this.accountTypeValidator.IsValid(accountTypeId);
        }

        public bool IsValid(string username)
        {
            return this.usernameValidator.IsValid(username);
        }
    }
}

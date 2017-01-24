using System.Text.RegularExpressions;
using NullReferencesDemo.Presentation.Interfaces.Validators;

namespace NullReferencesDemo.Presentation.Validators
{
    public class UsernameValidator : IUsernameValidator
    {
        private readonly Regex expression = new Regex("^[a-zA-Z][a-zA-Z0-9_]*$");

        public int MinLength
        {
            get
            {
                return 5;
            }
        }

        public bool IsValid(string username)
        {
            return !string.IsNullOrEmpty(username) &&
                username.Length >= this.MinLength &&
                this.expression.IsMatch(username);
        }
    }
}

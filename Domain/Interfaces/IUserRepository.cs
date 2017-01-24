using NullReferencesDemo.Common;

namespace NullReferencesDemo.Domain.Interfaces
{
    public interface IUserRepository
    {
        void Add(IUser user);
        Option<IUser> TryFind(string username);
    }
}

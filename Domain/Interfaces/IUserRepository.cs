using System.Collections.Generic;

namespace NullReferencesDemo.Domain.Interfaces
{
    public interface IUserRepository
    {
        void Add(IUser user);
        IEnumerable<IUser> Find(string username);
    }
}

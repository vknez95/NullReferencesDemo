using System.Collections.Generic;
using System.Linq;
using NullReferencesDemo.Common;
using NullReferencesDemo.Domain.Interfaces;

namespace NullReferencesDemo.Infrastructure.Implementation
{
    public class UserRepository : IUserRepository
    {

        private IList<IUser> users = new List<IUser>();

        public void Add(IUser user)
        {
            this.users.Add(user);
        }

        public Option<IUser> TryFind(string username)
        {

            return
                this.users
                    .Where(user => user.Username == username)
                    .Select(user => Option<IUser>.Create(user))
                    .LazyDefaultIfEmpty(() => Option<IUser>.CreateEmpty())
                    .Single();

        }
    }
}

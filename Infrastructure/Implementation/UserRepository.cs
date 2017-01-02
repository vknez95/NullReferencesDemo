using System;
using System.Collections.Generic;
using NullReferencesDemo.Domain.Interfaces;
using NullReferencesDemo.Common;

namespace NullReferencesDemo.Infrastructure.Implementation
{
    public class UserRepository : IUserRepository
    {

        private IDictionary<string, IUser> usernameToUser = new Dictionary<string, IUser>();

        public void Add(IUser user)
        {
            this.usernameToUser.Add(user.Username, user);
        }

        public Option<IUser> TryFind(string username)
        {

            IUser user = null;

            if (!this.usernameToUser.TryGetValue(username, out user))
                return Option<IUser>.CreateEmpty();

            return Option<IUser>.Create(user);
        }
    }
}

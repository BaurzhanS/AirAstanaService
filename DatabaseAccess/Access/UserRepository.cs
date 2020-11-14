using DatabaseAccess.Contracts;
using DatabaseAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.Access
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ApplicationContext ApplicationContext)
            : base(ApplicationContext)
        {
        }
    }
}

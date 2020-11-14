using DatabaseAccess.Contracts;
using DatabaseAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.Access
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationContext ApplicationContext)
            : base(ApplicationContext)
        {
        }
    }
}

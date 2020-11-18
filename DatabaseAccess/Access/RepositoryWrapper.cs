using DatabaseAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Access
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        ApplicationContext _repoContext;

        public RepositoryWrapper(ApplicationContext applicationContext)
        {
            _repoContext = applicationContext;
        }

        IFlightRepository _flight;
        IFlightStatusRepository _flightStatus;
        IRoleRepository _role;
        IUserRepository _user;

        public IFlightRepository Flight
        {
            get
            {
                if (_flight == null)
                {
                    _flight = new FlightRepository(_repoContext);
                }
                return _flight;
            }
        }
        public IFlightStatusRepository FlightStatus
        {
            get
            {
                if (_flightStatus == null)
                {
                    _flightStatus = new FlightStatusRepository(_repoContext);
                }
                return _flightStatus;
            }
        }
        public IRoleRepository Role
        {
            get
            {
                if (_role == null)
                {
                    _role = new RoleRepository(_repoContext);
                }
                return _role;
            }
        }
        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }
                return _user;
            }
        }

        public async Task Save()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}

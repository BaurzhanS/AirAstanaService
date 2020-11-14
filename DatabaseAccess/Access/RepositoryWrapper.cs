using DatabaseAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.Access
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        ApplicationContext _applicationContext;

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
                    _flight = new FlightRepository(_applicationContext);
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
                    _flightStatus = new FlightStatusRepository(_applicationContext);
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
                    _role = new RoleRepository(_applicationContext);
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
                    _user = new UserRepository(_applicationContext);
                }
                return _user;
            }
        }
    }
}

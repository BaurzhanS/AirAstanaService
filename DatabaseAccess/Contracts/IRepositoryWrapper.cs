using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.Contracts
{
    public interface IRepositoryWrapper
    {
        IFlightRepository Flight { get; }
        IFlightStatusRepository FlightStatus { get; }
        IRoleRepository Role { get; }
        IUserRepository User { get; }
    }
}

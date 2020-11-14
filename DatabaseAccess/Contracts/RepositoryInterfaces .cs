using DatabaseAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.Contracts
{
    public interface IFlightRepository: IRepositoryBase<Flight>
    {

    }
    public interface IFlightStatusRepository : IRepositoryBase<FlightStatus>
    {

    }
    public interface IRoleRepository : IRepositoryBase<Role>
    {

    }
    public interface IUserRepository : IRepositoryBase<User>
    {

    }
}

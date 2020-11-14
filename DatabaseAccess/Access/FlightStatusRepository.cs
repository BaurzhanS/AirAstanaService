using DatabaseAccess.Contracts;
using DatabaseAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.Access
{
    public class FlightStatusRepository : RepositoryBase<FlightStatus>, IFlightStatusRepository
    {
        public FlightStatusRepository(ApplicationContext ApplicationContext)
            : base(ApplicationContext)
        {
        }
    }
}

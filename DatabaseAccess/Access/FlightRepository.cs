using DatabaseAccess.Contracts;
using DatabaseAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.Access
{
    public class FlightRepository: RepositoryBase<Flight>, IFlightRepository
    {
        public FlightRepository(ApplicationContext ApplicationContext)
            : base(ApplicationContext)
        {
        }
    }
}

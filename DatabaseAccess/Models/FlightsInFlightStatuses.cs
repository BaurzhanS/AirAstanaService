using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.Models
{
    public class FlightsInFlightStatuses
    {
        public int Id { get; set; }

        public int FlightId { get; set; }
        public int FlightStatusId { get; set; }
        public FlightStatus FlightStatus { get; set; }
        public Flight Flight { get; set; }

    }
}

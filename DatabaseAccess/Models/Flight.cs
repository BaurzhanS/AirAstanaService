using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }

        public DateTime? DepartureTime { get; set; }
        public DateTime? DestinationTime { get; set; }

        public ICollection<FlightsInFlightStatuses> FlightsInFlightStatuses { get; set; }
    }
}

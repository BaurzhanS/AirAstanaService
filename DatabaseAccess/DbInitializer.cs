using DatabaseAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseAccess
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationContext context)
        {
            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            string adminRoleName = "admin";
            string userRoleName = "user";

            string adminEmail = "admin@mail.ru";
            string adminPassword = "1234";

            Role adminRole = new Role { Name = adminRoleName };
            Role userRole = new Role { Name = userRoleName };

            User adminUser = new User { Email = adminEmail, Password = adminPassword, RoleId = 1 };

            if (!context.Roles.Any())
            {
                context.Roles.AddRange(adminRole, userRole);

                context.SaveChanges();
            }
                

            if (!context.Users.Any())
            {
                context.Users.Add(adminUser);

                context.SaveChanges();
            }
                

            if (!context.Flights.Any())
            {
                List<Flight> flights = new List<Flight>
                {
                    new Flight
                    {
                        Departure = "Moskow",
                        DepartureTime = new DateTime(2020,10,20),
                        Destination = "Almaty",
                        DestinationTime = new DateTime(2020,10,21)
                    },
                    new Flight
                    {
                        Departure = "New-York",
                        DepartureTime = new DateTime(2020,10,23),
                        Destination = "Taraz",
                        DestinationTime = new DateTime(2020,10,25)
                    }
                };

                foreach (Flight f in flights)
                {
                    context.Flights.Add(f);
                }
                context.SaveChanges();
            }

            if (!context.FlightStatuses.Any())
            {
                List<FlightStatus> flightStatuses = new List<FlightStatus>
                {
                    new FlightStatus
                    {
                        StatusName = "Registration"
                    },
                    new FlightStatus
                    {
                        StatusName = "Delayed"
                    },
                    new FlightStatus
                    {
                        StatusName = "Departed"
                    },
                    new FlightStatus
                    {
                        StatusName = "Landed"
                    },
                    new FlightStatus
                    {
                        StatusName = "Arrived"
                    },
                    new FlightStatus
                    {
                        StatusName = "Canceled"
                    }
                };

                foreach (var f in flightStatuses)
                {
                    context.FlightStatuses.Add(f);
                }
                context.SaveChanges();
            }

            if (!context.FlightsInFlightStatuses.Any())
            {
                List<FlightsInFlightStatuses> flightsInFlightStatuses = new List<FlightsInFlightStatuses>
                {
                    new FlightsInFlightStatuses
                    {
                        FlightId = 1,
                        FlightStatusId = 1
                    },
                     new FlightsInFlightStatuses
                    {
                        FlightId = 2,
                        FlightStatusId = 2
                    },
                      new FlightsInFlightStatuses
                    {
                        FlightId = 1,
                        FlightStatusId = 3
                    },
                       new FlightsInFlightStatuses
                    {
                        FlightId = 2,
                        FlightStatusId = 1
                    }
                };

                foreach (var f in flightsInFlightStatuses)
                {
                    context.FlightsInFlightStatuses.Add(f);
                }
                context.SaveChanges();
            }
        }
    }
}

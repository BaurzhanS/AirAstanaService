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
            context.Database.EnsureCreated();

            string adminRoleName = "admin";
            string userRoleName = "user";

            string adminEmail = "admin@mail.ru";
            string adminPassword = "1234";

            Role adminRole = new Role { Id = 1, Name = adminRoleName };
            Role userRole = new Role { Id = 2, Name = userRoleName };

            User adminUser = new User { Id = 1, Email = adminEmail, Password = adminPassword, RoleId = adminRole.Id };

            context.Roles.AddRange(adminRole, userRole);
            context.Users.Add(adminUser);

            context.SaveChanges();

            List<Flight> flights = new List<Flight>
            {
                new Flight
                {
                    Id = 1,
                    Departure = "Moskow",
                    DepartureTime = new DateTime(2020,10,20),
                    Destination = "Almaty",
                    DestinationTime = new DateTime(2020,10,21)
                },
                new Flight
                {
                    Id = 2,
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
    }
}

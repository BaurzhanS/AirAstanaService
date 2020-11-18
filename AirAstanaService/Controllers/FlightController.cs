﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseAccess.Contracts;
using DatabaseAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirAstanaService.Controllers
{
    public class FlightController : Controller
    {
        private IRepositoryWrapper _repoWrapper;

        public FlightController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public IActionResult Index()
        {
            var flights = _repoWrapper.Flight.GetAll().ToList();

            //var test = _repoWrapper.Flight.FindByCondition(p => p.Id == 1).FirstOrDefault();

            //_repoWrapper.Flight.Insert(new Flight
            //{
            //    Departure = "London",
            //    DepartureTime = new DateTime(2020, 10, 24),
            //    Destination = "Almaty",
            //    DestinationTime = new DateTime(2020, 10, 27)
            //});
            //_repoWrapper.Save();

            User user = _repoWrapper.User.FindByCondition(u => u.Id == 1).Include(u=>u.Role).FirstOrDefault();

            return View(flights);
        }

        public IActionResult Edit(int Id)
        {
            var flights = _repoWrapper.Flight.GetAll().ToList();

            //var test = _repoWrapper.Flight.FindByCondition(p => p.Id == 1).FirstOrDefault();

            //_repoWrapper.Flight.Insert(new Flight
            //{
            //    Departure = "London",
            //    DepartureTime = new DateTime(2020, 10, 24),
            //    Destination = "Almaty",
            //    DestinationTime = new DateTime(2020, 10, 27)
            //});
            //_repoWrapper.Save();

            return View(flights);
        }
    }
}

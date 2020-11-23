using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AirAstanaService.Models;
using DatabaseAccess.Contracts;
using DatabaseAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var flights = _repoWrapper.Flight.FindByCondition(p=>p.DepartureTime>=DateTime.Now || p.DestinationTime>=DateTime.Now).Include(p => p.FlightStatus).ToList();

            return View(flights);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            var flightStatuses = new SelectList(_repoWrapper.FlightStatus.GetAll().ToList(), "Id", "StatusName");

            ViewBag.Statuses = flightStatuses;
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public IActionResult Create(FlightViewModel model)
        {
            var flight = new Flight
            {
                Departure = model.Departure,
                DepartureTime = model.DepartureTime,
                Destination = model.Destination,
                DestinationTime = model.DestinationTime,
                FlightStatusId = model.FlightStatusId,
                Note = model.Note
            };

            _repoWrapper.Flight.Insert(flight);
            _repoWrapper.Save();


            return RedirectToAction("Index", "Flight");
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(int? id)
        {
            var flightViewModel = new FlightViewModel();

            Flight flight = _repoWrapper.Flight.FindByCondition(p => p.Id == id).FirstOrDefault();

            if (flight != null)
            {
                flightViewModel.Id = flight.Id;
                flightViewModel.Departure = flight.Departure;
                flightViewModel.DepartureTime = flight.DepartureTime;
                flightViewModel.Destination = flight.Destination;
                flightViewModel.DestinationTime = flight.DestinationTime;
            }

            var flightStatuses = new SelectList(_repoWrapper.FlightStatus.GetAll().ToList(), "Id", "StatusName");

            ViewBag.Statuses = flightStatuses;
            return View("Edit", flightViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(FlightViewModel model)
        {
            var flight = _repoWrapper.Flight.FindByCondition(p => p.Id == model.Id).FirstOrDefault();

            if (flight != null)
            {
                _repoWrapper.Flight.Update(flight);
                _repoWrapper.Save();
            }

            return RedirectToAction("Index", "Flight");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int Id)
        {
            var flight = _repoWrapper.Flight.FindByCondition(p => p.Id == Id).FirstOrDefault();

            if (flight != null)
            {
                _repoWrapper.Flight.Delete(flight);
                _repoWrapper.Save();
            }

            return RedirectToAction("Index", "Flight");
        }
    }
}

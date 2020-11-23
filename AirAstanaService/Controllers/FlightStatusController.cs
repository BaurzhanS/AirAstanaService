using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseAccess.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirAstanaService.Controllers
{
    public class FlightStatusController : Controller
    {
        private IRepositoryWrapper _repoWrapper;

        public FlightStatusController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public IActionResult Index()
        {
            var flightStatuses = _repoWrapper.FlightStatus.GetAll().ToList();

            return View(flightStatuses);
        }

        public IActionResult Edit(int Id)
        {
            var flights = _repoWrapper.Flight.GetAll().Include(p => p.FlightStatus).ToList();

            return View(flights);
        }
    }
}

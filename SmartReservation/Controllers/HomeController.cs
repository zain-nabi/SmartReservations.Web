using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartReservation.Interface;
using SmartReservation.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SmartReservation.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IDashboard _dashboard;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IDashboard dashboard)
        {
            _logger = logger;
            _dashboard = dashboard;
        }

        public async Task<IActionResult> Index()
        {
            var DashboardViewModel = new DashboardViewModel();
            DashboardViewModel.ReservationArrived = await _dashboard.GetArrivedReservations();
            DashboardViewModel.ReservationBooked = await _dashboard.GetBookedReservations();
            DashboardViewModel.ReservationComplete = await _dashboard.GetCompleteReservations();
            return View(DashboardViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmartReservation.Interface;
using SmartReservation.Model;
using SmartReservation.Models;
using SmartReservation.Utils;
using System;
using System.Threading.Tasks;

namespace SmartReservation.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservation _rservation;
        private readonly IReservationStatus _reservationStatus;
        private readonly IRestaurant _restaurant;

        public ReservationController(IReservation rservation, IRestaurant restaurant, IReservationStatus reservationStatus)
        {
            _rservation = rservation;
            _restaurant = restaurant;
            _reservationStatus = reservationStatus;
        }

        [HttpGet]
        public async Task<IActionResult> Create(int RestaurantID)
        {
            var ReservationViewModel = new ReservationViewModel()
            {
                Restaurants = new SelectList(await _restaurant.Restaurants(), "restaurantID", "Name")
            };
            if (RestaurantID == 0)
            {

                return View(ReservationViewModel);
            }
            else
            {
                ReservationViewModel.RestaurantID = RestaurantID;
                return View(ReservationViewModel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReservationViewModel model)
        {
            var reservation = new Reservation()
            {
                People = model.Reservation.People,
                RestaurantID = model.RestaurantID,
                Time = model.Reservation.Time,
                Name = model.Reservation.Name,
                Cell = model.Reservation.Cell,
                OrderTotalID = 0,
                ReservationStatusID = 1,
                CreatedByUserID = User.GetUserId(),
                CreatedOn = DateTime.Now
            };

            var result = await _rservation.CreateAsync(reservation);
            return RedirectToAction("Reservations");
        }

        [HttpGet]
        public async Task<IActionResult> Reservations(int userID = 0)
        {
            if(userID == 0)
            {
                var result = await _rservation.UserReservations(User.GetUserId());
                return View(result);
            }
            else
            {
                var result = await _rservation.UserReservations(userID);
                return View(result);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(int ReservationID)
        {
            var ReservationViewModel = new ReservationViewModel();
            ReservationViewModel.Reservation = new Reservation();
            var result = await _rservation.FindByIdAsync(ReservationID);
            ReservationViewModel.Reservation = result;
            ReservationViewModel.Reservation.reservationID = ReservationID;
            ReservationViewModel.Restaurants = new SelectList(await _restaurant.Restaurants(), "restaurantID", "Name");
            ReservationViewModel.ReservationStatusList = new SelectList(await _reservationStatus.ReservationStatuses(), "reservationstatusID", "Status");
            return View(ReservationViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ReservationViewModel model)
        {
            var Reservation = new Reservation()
            {
                reservationID = model.Reservation.reservationID,
                People = model.Reservation.People,
                RestaurantID = model.Reservation.RestaurantID,
                Time = model.Reservation.Time,
                Name = model.Reservation.Name,
                Cell = model.Reservation.Cell,
                OrderTotalID = model.Reservation.OrderTotalID,
                ReservationStatusID = model.Reservation.ReservationStatusID,
                CreatedOn = DateTime.Now,
                CreatedByUserID = User.GetUserId()
            };
            var result = await _rservation.UpdateAsync(Reservation);
            return RedirectToAction("Reservations", "Reservation");
        }

        [HttpGet]
        public async Task<IActionResult> Arrived(int ReservationID, int ReservationStatusID)
        {
            var ReservationViewModel = new ReservationViewModel();
            ReservationViewModel.Reservation = new Reservation();
            var reservation = await _rservation.FindByIdAsync(ReservationID);
            reservation.ReservationStatusID = ReservationStatusID;
            var result = await _rservation.UpdateAsync(reservation);
            return RedirectToAction("Reservations", "Reservation", new { userID = User.GetUserId() });
        }

        [HttpGet]
        public async Task<IActionResult> Complete(int ReservationID, int ReservationStatusID)
        {
            var ReservationViewModel = new ReservationViewModel();
            ReservationViewModel.Reservation = new Reservation();
            var reservation = await _rservation.FindByIdAsync(ReservationID);
            reservation.ReservationStatusID = ReservationStatusID;
            var result = await _rservation.UpdateAsync(reservation);
            return RedirectToAction("Reservations", "Reservation", new { userID = User.GetUserId() });
        }

        [HttpGet]
        public async Task<IActionResult> AllReservations()
        {
            var result = await _rservation.Reservations();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> AdminUpdate(int ReservationID)
        {
            var ReservationViewModel = new ReservationViewModel();
            ReservationViewModel.Reservation = new Reservation();
            var result = await _rservation.FindByIdAsync(ReservationID);
            ReservationViewModel.Reservation = result;
            ReservationViewModel.Reservation.reservationID = ReservationID;
            ReservationViewModel.Restaurants = new SelectList(await _restaurant.Restaurants(), "restaurantID", "Name");
            ReservationViewModel.ReservationStatusList = new SelectList(await _reservationStatus.ReservationStatuses(), "reservationstatusID", "Status");
            return View(ReservationViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AdminUpdate(ReservationViewModel model)
        {
            var Reservation = new Reservation()
            {
                reservationID = model.Reservation.reservationID,
                People = model.Reservation.People,
                RestaurantID = model.Reservation.RestaurantID,
                Time = model.Reservation.Time,
                Name = model.Reservation.Name,
                Cell = model.Reservation.Cell,
                OrderTotalID = model.Reservation.OrderTotalID,
                ReservationStatusID = model.Reservation.ReservationStatusID,
                CreatedOn = DateTime.Now,
                CreatedByUserID = model.Reservation.reservationID
            };
            var result = await _rservation.UpdateAsync(Reservation);
            return RedirectToAction("AllReservations", "Reservation");
        }

        [HttpGet]
        public async Task<IActionResult> AdminArrived(int ReservationID, int ReservationStatusID)
        {
            var ReservationViewModel = new ReservationViewModel();
            ReservationViewModel.Reservation = new Reservation();
            var reservation = await _rservation.FindByIdAsync(ReservationID);
            reservation.ReservationStatusID = ReservationStatusID;
            var result = await _rservation.UpdateAsync(reservation);
            return RedirectToAction("AllReservations", "Reservation", new { userID = User.GetUserId() });
        }

        [HttpGet]
        public async Task<IActionResult> AdminComplete(int ReservationID, int ReservationStatusID)
        {
            var ReservationViewModel = new ReservationViewModel();
            ReservationViewModel.Reservation = new Reservation();
            var reservation = await _rservation.FindByIdAsync(ReservationID);
            reservation.ReservationStatusID = ReservationStatusID;
            var result = await _rservation.UpdateAsync(reservation);
            return RedirectToAction("AllReservations", "Reservation", new { userID = User.GetUserId() });
        }
    }
}

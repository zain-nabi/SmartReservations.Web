using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
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
                Restaurants = new SelectList(await _restaurant.Restaurants(), "restaurantID", "Name"),
                ReservationExistMessage = null
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
            string newReservationDate = model.Reservation.ReservationTime.ToString();
            var checkIfReservationExist = await _rservation.CheckIfReservationExist(newReservationDate);
            if(checkIfReservationExist.Name == "True")
            {
                model.Restaurants = new SelectList(await _restaurant.Restaurants(), "restaurantID", "Name");
                model.ReservationExistMessage = "Reservation already Exist";
                return View(model);
            }
            var reservation = new Reservation()
            {
                People = model.Reservation.People,
                RestaurantID = model.RestaurantID,
                ReservationTime = model.Reservation.ReservationTime,
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
            ReservationViewModel.TimeExist = "False";
            ReservationViewModel.TimeExistMessge = null;
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
                ReservationTime = model.Reservation.ReservationTime,
                Name = model.Reservation.Name,
                Cell = model.Reservation.Cell,
                OrderTotalID = model.Reservation.OrderTotalID,
                ReservationStatusID = model.Reservation.ReservationStatusID,
                CreatedOn = DateTime.Now,
                CreatedByUserID = User.GetUserId()
            };
            var result = await _rservation.CheckIfReservationExist(model.Reservation.ReservationTime.ToString());
            var MenuDetails = await _rservation.FindByIdAsync(model.Reservation.reservationID);
            if (MenuDetails.ReservationTime == model.Reservation.ReservationTime)
            {
                if (MenuDetails.ReservationTime != model.Reservation.ReservationTime)
                {
                    if (MenuDetails.ReservationTime == model.Reservation.ReservationTime)
                    {
                        model.TimeExist = "";
                    }
                    if (MenuDetails.ReservationTime != model.Reservation.ReservationTime)
                    {
                        model.TimeExistMessge = "Reservation Exist";
                    }
                    if (result.Name == "False")
                    {
                        await _rservation.UpdateAsync(Reservation);
                        return RedirectToAction("Reservations", "Reservation");
                    }
                    else
                    {
                        model.Restaurants = new SelectList(await _restaurant.Restaurants(), "restaurantID", "Name");
                        model.ReservationStatusList = new SelectList(await _reservationStatus.ReservationStatuses(), "reservationstatusID", "Status");
                        model.TimeExistMessge = "Reservation Exist";
                        model.TimeExist = "True";
                        return View(model);
                    }
                }
                await _rservation.UpdateAsync(Reservation);
                return RedirectToAction("Reservations", "Reservation");
            }


            if (MenuDetails.ReservationTime == model.Reservation.ReservationTime)
            {
                model.TimeExist = "";
            }
            if (MenuDetails.ReservationTime != model.Reservation.ReservationTime)
            {
                model.TimeExistMessge = "Reservation Exist";
            }
            if (result.Name == "False")
            {
                await _rservation.UpdateAsync(Reservation);
                return RedirectToAction("Reservations", "Reservation");
            }
            else
            {
                model.Restaurants = new SelectList(await _restaurant.Restaurants(), "restaurantID", "Name");
                model.ReservationStatusList = new SelectList(await _reservationStatus.ReservationStatuses(), "reservationstatusID", "Status");
                model.TimeExistMessge = "Reservation Exist";
                model.TimeExist = "True";
                return View(model);
            }

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
                ReservationTime = model.Reservation.ReservationTime,
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

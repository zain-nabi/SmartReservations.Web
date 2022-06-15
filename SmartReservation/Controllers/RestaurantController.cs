using Microsoft.AspNetCore.Mvc;
using SmartReservation.Interface;
using SmartReservation.Model;
using SmartReservation.Service;
using SmartReservation.Utils;
using System;
using System.Threading.Tasks;

namespace SmartReservation.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRestaurant _restaurant;

        public RestaurantController(IRestaurant restaurant)
        {
            _restaurant = restaurant;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Restaurant model)
        {
            var restaurant = new Restaurant()
            {
                Name = model.Name,
                Location = model.Location,
                Phone = model.Phone,
                Active = model.Active,
                CreatedOn = DateTime.Now,
                CreatedByUserID = User.GetUserId()
            };

            var result = await _restaurant.CreateAsync(restaurant);

            return RedirectToAction("Restaurants");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int RestaurantID)
        {
            var result = await _restaurant.FindByIdAsync(RestaurantID);
            result.restaurantID = RestaurantID;
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Restaurant model)
        {
            var restaurant = new Restaurant()
            {
                restaurantID = model.restaurantID,
                Name = model.Name,
                Location = model.Location,
                Phone = model.Phone,
                Active = model.Active,
                CreatedOn = DateTime.Now,
                CreatedByUserID = User.GetUserId()
            };

            var result = await _restaurant.UpdateAsync(restaurant);

            return RedirectToAction("Restaurants");
        }

        [HttpGet]
        public async Task<IActionResult> Restaurants()
        {
            var result = await _restaurant.Restaurants();
            return View(result);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SmartReservation.Interface;
using SmartReservation.Model;
using SmartReservation.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SmartReservation.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrder _order;
        private readonly IMenuItem _menuItem;
        public OrderController(IOrder order, IMenuItem menuItem)
        {
            _menuItem = menuItem;
            _order = order;
        }

        [HttpGet]
        public async Task<IActionResult> Create(int reservationID, int RestaurantID, int NoOfPeople)
        {
            var OrderViewModel = new SmartReservation.Models.OrderViewModel();
            OrderViewModel.Order = new Order();
            OrderViewModel.ReservationID = reservationID;
            OrderViewModel.RestaurantID = RestaurantID;
            OrderViewModel.NoOfPeople = NoOfPeople;
            OrderViewModel.MenuItemsList = new SelectList(await _menuItem.Items(), "MenuItemID", "Name");
            return View(OrderViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SmartReservation.Models.OrderViewModel model)
        {
            model.OrderLines =
            JsonConvert.DeserializeObject<List<Order>>(WebUtility.UrlDecode(model.QuoteLineHF) ?? string.Empty);
            model.OrderLines = model.OrderLines.Where(x => x.Item != null).ToList();
            var Items = new List<MenuItem>();
            foreach (var item in await _menuItem.Items())
            {
                Items.Add(item);
            }
           
            foreach (var item in model.OrderLines)
            {
                item.Price = Items.Where(x => x.Name == item.Item).Select(x => x.Price).FirstOrDefault();
                item.RestaurantID = model.RestaurantID;
                item.ReservationID = model.ReservationID;
                item.CreatedOn = DateTime.Now;
                item.CreatedByUserID = User.GetUserId();
            }

            var OrderCustomModel = new SmartReservation.Model.Custom.OrderCustomModel();
            OrderCustomModel.Orders = model.OrderLines;
            var result = await _order.CreateAsync(OrderCustomModel);
            return RedirectToAction("Reservations", "Reservation");
        }

        [HttpGet]
        public async Task<IActionResult> ReservationOrders(int ReservationID)
        {
            var result = await _order.FindByReservationOrderByIdAsync(ReservationID);
            return View(result);
        }
    }
}

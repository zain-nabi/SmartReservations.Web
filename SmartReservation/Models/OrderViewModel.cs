using Microsoft.AspNetCore.Mvc.Rendering;
using SmartReservation.Model;
using System.Collections.Generic;

namespace SmartReservation.Models
{
    public class OrderViewModel
    {
        public Order Order { get; set; }
        public int OrderID { get; set; }
        public int ReservationID { get; set; }
        public int MenuItemID { get; set; }
        public int RestaurantID { get; set; }
        public string QuoteLineHF { get; set; }
        public int NoOfPeople { get; set; }
        public IEnumerable<SelectListItem> MenuItemsList { get; set; }
        public List<Order> OrderLines { get; set; }
    }
}

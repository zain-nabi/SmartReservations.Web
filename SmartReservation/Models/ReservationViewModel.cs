using Microsoft.AspNetCore.Mvc.Rendering;
using SmartReservation.Model;
using System.Collections.Generic;

namespace SmartReservation.Models
{
    public class ReservationViewModel
    {
        public IEnumerable<SelectListItem> ReservationStatusList { get; set; }
        public Reservation Reservation { get; set; }
        public int RestaurantID { get; set; }
        public string ReservationExistMessage { get; set; }
        public IEnumerable<SelectListItem> Restaurants { get; set; }
        public string TimeExist { get; set; }
        public string TimeExistMessge { get; set; }
    }
}

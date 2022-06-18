using SmartReservation.Model;

namespace SmartReservation.Models
{
    public class DashboardViewModel
    {
        public ReservationArrived ReservationArrived { get; set; }
        public ReservationBooked ReservationBooked { get; set; }
        public ReservationComplete ReservationComplete { get; set; }
    }
}

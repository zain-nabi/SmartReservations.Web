using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartReservation.Interface
{
    public interface IReservation
    {
        Task<Model.Reservation> CreateAsync(Model.Reservation Reservation);
        Task<bool> UpdateAsync(Model.Reservation Reservation);
        Task<List<Model.Reservation>> FindReservationByIdAsync(int ReservationID);
        Task<List<Model.Reservation>> FindReservationRestaurantByIdAsync(int RestaurantID);
        Task<List<Model.Reservation>> UserReservations(int userID);
        Task<List<Model.Reservation>> Reservations();
        Task<Model.Reservation> FindByIdAsync(int ReservationID);
        Task<Model.Reservation> CheckIfReservationExist(string ReservationDate);
    }
}

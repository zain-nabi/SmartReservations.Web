using Microsoft.Extensions.Configuration;
using SmartReservation.Interface;
using SmartReservation.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SmartReservation.Service
{
    public class ReservationService : IReservation
    {
        private static Connection _connection;

        public ReservationService(IConfiguration configuration, IHttpClientFactory factory)
        {
            _connection = new Connection(configuration, factory);
        }
        public async Task<Reservation> CreateAsync(Reservation Reservation)
        {
            return await _connection.PostAsync("Reservation", "CreateAsync", Reservation);
        }

        public async Task<List<Reservation>> FindReservationByIdAsync(int ReservationID)
        {
            return await _connection.GetAsync<List<Reservation>>("Reservation", $"FindReservationByIdAsync?ReservationID={ReservationID}");
        }

        public async Task<List<Reservation>> FindReservationRestaurantByIdAsync(int RestaurantID)
        {
            return await _connection.GetAsync<List<Reservation>>("Reservation", $"FindReservationRestaurantByIdAsync?RestaurantID={RestaurantID}");
        }

        public async Task<List<Reservation>> Reservations()
        {
            return await _connection.GetAsync<List<Reservation>>("Reservation", "Reservations", "v1");
        }

        public async Task<bool> UpdateAsync(Reservation Reservation)
        {
            return await _connection.PutAsync("Reservation", "UpdateAsync", Reservation);
        }

        public async Task<List<Reservation>> UserReservations(int userID)
        {
            return await _connection.GetAsync<List<Reservation>>("Reservation", $"UserReservations?userID={userID}");
        }

        public async Task<Reservation> FindByIdAsync(int ReservationID)
        {
            return await _connection.GetAsync<Reservation>("Reservation", $"FindByIdAsync?ReservationID={ReservationID}");
        }
    }
}

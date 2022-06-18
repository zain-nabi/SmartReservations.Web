using Microsoft.Extensions.Configuration;
using SmartReservation.Interface;
using SmartReservation.Model;
using System.Net.Http;
using System.Threading.Tasks;

namespace SmartReservation.Service
{
    public class DashboardService : IDashboard
    {
        private static Connection _connection;

        public DashboardService(IConfiguration configuration, IHttpClientFactory factory)
        {
            _connection = new Connection(configuration, factory);
        }

        public async Task<ReservationArrived> GetArrivedReservations()
        {
            return await _connection.GetAsync<ReservationArrived>("Dashboard", $"GetArrivedReservations", "v1");
        }

        public async Task<ReservationBooked> GetBookedReservations()
        {
            return await _connection.GetAsync<ReservationBooked>("Dashboard", $"GetBookedReservations", "v1");
        }

        public async Task<ReservationComplete> GetCompleteReservations()
        {
            return await _connection.GetAsync<ReservationComplete>("Dashboard", $"GetCompleteReservations", "v1");
        }
    }
}

using Microsoft.Extensions.Configuration;
using SmartReservation.Interface;
using SmartReservation.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SmartReservation.Service
{
    public class ReservationStatusService : IReservationStatus
    {
        private static Connection _connection;

        public ReservationStatusService(IConfiguration configuration, IHttpClientFactory factory)
        {
            _connection = new Connection(configuration, factory);
        }

        public async Task<List<ReservationStatus>> ReservationStatuses()
        {
            return await _connection.GetAsync<List<ReservationStatus>>("ReservationStatus", "ReservationStatuses", "v1");
        }
    }
}

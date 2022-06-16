using Microsoft.Extensions.Configuration;
using SmartReservation.Interface;
using SmartReservation.Model;
using SmartReservation.Model.Custom;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SmartReservation.Service
{
    public class OrderRepository : IOrder
    {
        private static Connection _connection;

        public OrderRepository(IConfiguration configuration, IHttpClientFactory factory)
        {
            _connection = new Connection(configuration, factory);
        }

        public async Task<OrderCustomModel> CreateAsync(OrderCustomModel Order)
        {
            return await _connection.PostAsync("Order", "CreateAsync", Order);
        }

        public async Task<List<Order>> FindByReservationOrderByIdAsync(int ReservationID)
        {
            return await _connection.GetAsync<List<Order>>("Order", $"FindByReservationOrderByIdAsync?ReservationID={ReservationID}");
        }

        public async Task<List<Order>> FindByRestaurantOrderByIdAsync(int RestaurantID)
        {
            return await _connection.GetAsync<List<Order>>("Order", $"FindByRestaurantOrderByIdAsync?RestaurantID={RestaurantID}");
        }

        public async Task<List<Order>> Orders(int orderID)
        {
            return await _connection.GetAsync<List<Order>>("Order", $"Orders?orderID={orderID}");
        }

        public async Task<bool> UpdateAsync(Order Order)
        {
            return await _connection.PutAsync("Reservation", "UpdateAsync", Order);
        }
    }
}

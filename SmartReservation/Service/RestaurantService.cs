using Microsoft.Extensions.Configuration;
using SmartReservation.Interface;
using SmartReservation.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SmartReservation.Service
{
    public class RestaurantService : IRestaurant
    {
        private static Connection _connection;

        public RestaurantService(IConfiguration configuration, IHttpClientFactory factory)
        {
            _connection = new Connection(configuration, factory);
        }

        public async Task<Restaurant> CreateAsync(Restaurant Restaurant)
        {
            return await _connection.PostAsync("Restaurant", "CreateAsync", Restaurant);
        }

        public async Task<Restaurant> FindByIdAsync(int RestaurantID)
        {
            return await _connection.GetAsync<Restaurant>("Restaurant", $"FindByIdAsync?RestaurantID={RestaurantID}");
        }

        public async Task<List<Restaurant>> Restaurants()
        {
            return await _connection.GetAsync<List<Restaurant>>("Restaurant", "Restaurants", "v1");
        }

        public async Task<bool> UpdateAsync(Restaurant Restaurant)
        {
            return await _connection.PutAsync("Restaurant", "UpdateAsync", Restaurant);
        }

        public async Task<List<Restaurant>> UserRestaurants(int userID)
        {
            return await _connection.GetAsync<List<Restaurant>>("Restaurant", $"UserRestaurants?userID={userID}");
        }
    }
}

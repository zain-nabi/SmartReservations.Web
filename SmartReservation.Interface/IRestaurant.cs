using SmartReservation.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartReservation.Interface
{
    public interface IRestaurant
    {
        Task<Restaurant> CreateAsync(Restaurant Restaurant);
        Task<bool> UpdateAsync(Restaurant Restaurant);
        Task<List<Restaurant>> UserRestaurants(int userID);
        Task<Restaurant> FindByIdAsync(int RestaurantID);
        Task<List<Restaurant>> Restaurants();
    }
}

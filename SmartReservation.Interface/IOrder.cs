using SmartReservation.Model.Custom;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartReservation.Interface
{
    public interface IOrder
    {
        Task<OrderCustomModel> CreateAsync(OrderCustomModel Order);
        Task<bool> UpdateAsync(Model.Order Order);
        Task<List<Model.Order>> Orders(int orderID);
        Task<List<Model.Order>> FindByRestaurantOrderByIdAsync(int RestaurantID);
        Task<List<Model.Order>> FindByReservationOrderByIdAsync(int ReservationID);
    }
}

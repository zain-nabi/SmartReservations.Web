using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartReservation.Interface
{
    public interface ITableSettings
    {
        Task<List<Model.TableSettings>> Tables(int RestaurantID);
        Task<Model.TableSettings> CreateAsync(Model.TableSettings TableSettings);
        Task<bool> UpdateAsync(Model.TableSettings TableSettings);
    }
}

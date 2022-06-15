using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartReservation.Interface
{
    public interface IMenuItem
    {
        Task<Model.MenuItem> CreateAsync(Model.MenuItem MenuItem);
        Task<bool> UpdateAsync(Model.MenuItem MenuItem);
        Task<Model.MenuItem> FindByIdAsync(int MenuItemID);
        Task<List<Model.MenuItem>> Items();
    }
}

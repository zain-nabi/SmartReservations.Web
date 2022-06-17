using Microsoft.Extensions.Configuration;
using SmartReservation.Interface;
using SmartReservation.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SmartReservation.Service
{
    public class MenuItemService : IMenuItem
    {
        private static Connection _connection;

        public MenuItemService(IConfiguration configuration, IHttpClientFactory factory)
        {
            _connection = new Connection(configuration, factory);
        }

        public async Task<MenuItem> CreateAsync(MenuItem MenuItem)
        {
            return await _connection.PostAsync("MenuItem", "CreateAsync", MenuItem);
        }

        public async Task<MenuItem> FindByIdAsync(int MenuItemID)
        {
            return await _connection.GetAsync<MenuItem>("MenuItem", $"FindByIdAsync?MenuItemID={MenuItemID}");
        }

        public async Task<bool> UpdateAsync(MenuItem MenuItem)
        {
            return await _connection.PutAsync("MenuItem", "UpdateAsync", MenuItem);
        }

        public async Task<List<MenuItem>> Items()
        {
            return await _connection.GetAsync<List<MenuItem>>("MenuItem", $"Items" , "v1");
        }

        public async Task<MenuItem> CheckIfMenuItemExist(string MenuItem)
        {
            return await _connection.GetAsync<MenuItem>("MenuItem", $"CheckIfMenuItemExist?MenuItem={MenuItem}");
        }
    }
}

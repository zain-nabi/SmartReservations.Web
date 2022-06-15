using Microsoft.Extensions.Configuration;
using SmartReservation.Interface;
using SmartReservation.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SmartReservation.Service
{
    public class TableSettingsService : ITableSettings
    {
        private static Connection _connection;

        public TableSettingsService(IConfiguration configuration, IHttpClientFactory factory)
        {
            _connection = new Connection(configuration, factory);
        }

        public async Task<TableSettings> CreateAsync(TableSettings TableSettings)
        {
            return await _connection.PostAsync("TableSettings", "CreateAsync", TableSettings);
        }

        public async Task<List<TableSettings>> Tables(int RestaurantID)
        {
            return await _connection.GetAsync<List<TableSettings>>("TableSettings", $"Tables?RestaurantID={RestaurantID}");
        }

        public async Task<bool> UpdateAsync(TableSettings TableSettings)
        {
            return await _connection.PutAsync("TableSettings", "UpdateAsync", TableSettings);
        }
    }
}

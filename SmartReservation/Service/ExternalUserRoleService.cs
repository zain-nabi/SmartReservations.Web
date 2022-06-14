using Microsoft.Extensions.Configuration;
using SmartReservation.Interface;
using SmartReservation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SmartReservation.Service
{
    public class ExternalUserRoleService : IExternalUserRole
    {
        private static Connection _connection;

        public ExternalUserRoleService(IConfiguration configuration, IHttpClientFactory factory)
        {
            _connection = new Connection(configuration, factory);
        }

        /// <summary>
        /// Gets the UserRoles by UserRoleID
        /// </summary>
        /// <param name="userRoleId"></param>
        /// <returns>Returns a single UserRole</returns>
        public async Task<ExternalUserRole> GetUserRole(int userRoleId)
        {
            return await _connection.GetAsync<ExternalUserRole>("User", $"/{"UserRoles"}/{userRoleId}");

        }

        public async Task<long> Post(ExternalUserRole userRoles, string dbName)
        {
            return await _connection.PostAsyncLong("User", $"{"UserRoles"}?dbName={dbName}", userRoles);
        }

        public async Task<bool> Put(ExternalUserRole userRoles, string dbName)
        {
            return await _connection.PutAsync("User", $"{"UserRoles"}?dbName={dbName}", userRoles);
        }

        public async Task<List<Roles>> GetRolesByUserId(int userId, string dbName)
        {
            return await _connection.GetAsync<List<Roles>>("User", $"/{"Roles"}/{userId}/{dbName}");
        }

        /// <summary>
        /// Get a list of Roles using an IN statement in the query for the RoleID's
        /// </summary>
        /// <param name="roleIDs"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public async Task<List<Roles>> GetRolesByIds(string roleIDs, string dbName)
        {
            return await _connection.GetAsync<List<Roles>>("User", $"/{"UserRoles"}/{roleIDs}/{dbName}");
        }

        public async Task<List<Roles>> GetActiveUserRoles()
        {
            return await _connection.GetAsync<List<Roles>>("User", $"/GetActiveUserRoles");
        }

        public async Task<ExternalUserRole> GetUserRoleByID(int externalUserID)
        {
            return await _connection.GetAsync<ExternalUserRole>("User", $"/GetUserRoleByID/{externalUserID}");

        }
    }
}

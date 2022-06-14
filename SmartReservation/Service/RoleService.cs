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
    public class RoleService : IRole
    {
        private readonly Connection _connection;

        public RoleService(IConfiguration configuration, IHttpClientFactory factory)
        {
            _connection = new Connection(configuration, factory);
        }

        /// <summary>
        /// Get the users roles as a List
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public async Task<List<Roles>> GetRolesByUserId(int userId, string dbName)
        {
            return await _connection.GetAsync<List<Roles>>("User", $" /{"Roles"}/{userId}/{dbName}");
        }

        /// <summary>
        /// Get a list of Roles using an IN statement in the query for the RoleID's
        /// </summary>
        /// <param name="roleIDs"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public async Task<List<Roles>> GetRolesByIds(string roleIDs, string dbName)
        {
            return await _connection.GetAsync<List<Roles>>("User", $"/{"Roles"}/{roleIDs}/{dbName}");
        }
    }
}

using SmartReservation.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartReservation.Model;
using Microsoft.Extensions.Configuration;
using System.Net.Http;

namespace SmartReservation.Service
{
    public class ExternalUserService : IExternalUser
    {
        private static Connection _connection;

        public ExternalUserService(IConfiguration configuration, IHttpClientFactory factory)
        {
            _connection = new Connection(configuration, factory);
        }

        /// <summary>
        /// Gets the user by their username
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Returns a single user</returns>
        public async Task<ExternalUser> FindByNameAsync(string username)
        {
            return await _connection.GetAsync<ExternalUser>("User", $"/{username}");
        }

        /// <summary>
        /// Creates a new user and returns the user object
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Returns a user object</returns>
        public async Task<ExternalUser> CreateAsync(ExternalUser user)
        {
            return await _connection.PostAsync("User", "CreateAsync", user);
        }

        /// <summary>
        /// Creates a new user and returns a UserID
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Returns a UserID</returns>
        public async Task<long> Post(ExternalUser user)
        {
            return await _connection.PostAsyncLong("User", "", user);
        }

        /// <summary>
        /// Updates an existing user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Returns a boolean</returns>
        public async Task<bool> PutUpdateAsync(ExternalUser user)
        {
            return await _connection.PutAsync("User", "", user);
        }

        /// <summary>
        /// Gets the user by their UserID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Returns a single user</returns>
        public async Task<ExternalUser> FindByIdAsync(int userId)
        {
            return await _connection.GetAsync<ExternalUser>("User", $"/{userId}");
        }

        /// <summary>
        /// Gets all the users including locked out users
        /// </summary>
        /// <returns>Returns a list of users</returns>
        public async Task<List<ExternalUser>> GetAllUsersInclLockedOut()
        {
            return await _connection.GetAsync<List<ExternalUser>>("User", "", null);
        }

        /// <summary>
        /// Gets the User/UserRoles and Roles for creating views
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleIds"></param>
        /// <returns>Returns a UserWithRoles model</returns>
        public async Task<List<ExternalUserModel>> GetUserWithRoles()
        {
            return await _connection.GetAsync<List<ExternalUserModel>>("User", $"/GetUserWithRoles");
        }

        public async Task<ExternalUser> CheckIfEmailExist(string email)
        {
            return await _connection.GetAsync<ExternalUser>("User", $"/CheckIfEmailExist/{email}");
        }

        public async Task<ExternalUserModel> FindByExternalUserID(int externalUserID)
        {
            return await _connection.GetAsync<ExternalUserModel>("User", $"/FindByExternalUserID/{externalUserID}");
        }
    }
}

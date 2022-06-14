﻿using SmartReservation.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartReservation.Interface
{
    public interface IExternalUser
    {
        Task<ExternalUser> FindByNameAsync(string username);
        Task<ExternalUser> CreateAsync(ExternalUser user);
        Task<long> Post(ExternalUser user);
        Task<bool> PutUpdateAsync(ExternalUser user);
        Task<ExternalUser> FindByIdAsync(int userId);
        Task<List<ExternalUser>> GetAllUsersInclLockedOut();
        Task<List<ExternalUserModel>> GetUserWithRoles();
        Task<ExternalUser> CheckIfEmailExist(string email);
        Task<ExternalUserModel> FindByExternalUserID(int externalUserID);
    }
}

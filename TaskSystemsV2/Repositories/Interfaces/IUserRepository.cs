﻿using TaskSystemsV2.Models;

namespace TaskSystemsV2.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllUsers();

        Task<UserModel> GetUserById(int id);

        Task<UserModel> InsertUser(UserModel user);

        Task<UserModel> UpdateUser(UserModel user, int id);

        Task DeleteUser(int id);
    }
}
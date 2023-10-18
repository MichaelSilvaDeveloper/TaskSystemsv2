using Microsoft.EntityFrameworkCore;
using TaskSystemsV2.Data;
using TaskSystemsV2.Models;
using TaskSystemsV2.Repositories.Interfaces;

namespace TaskSystemsV2.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskSystemDBContextV2 _dBContext;

        public UserRepository(TaskSystemDBContextV2 dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _dBContext.Users.ToListAsync();
        }

        public async Task<UserModel> GetUserById(int id)
        {
            var searchUserById = await _dBContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (searchUserById == null)
                throw new Exception($"Usuário para o id: {id} não foi encontrado");
            return searchUserById;
        }

        public async Task<UserModel> InsertUser(UserModel user)
        {
            await _dBContext.Users.AddAsync(user);
            await _dBContext.SaveChangesAsync();
            return user;
        }

        public async Task<UserModel> UpdateUser(UserModel user, int id)
        {
            var editUserById = await GetUserById(id);
            if(editUserById == null)
                throw new Exception($"Usuário para o id: {id} não foi encontrado");

            //editUserById.Name = user.Name;
            //editUserById.Email = user.Email;

            _dBContext.Users.Update(editUserById);
            await _dBContext.SaveChangesAsync();
            return editUserById;
        }

        public async Task DeleteUser(int id)
        {
            var deleteUserById = await GetUserById(id);
            if (deleteUserById == null)
                throw new Exception($"Usuário para o id: {id} não foi encontrado");

            _dBContext.Users.Remove(deleteUserById);
            await _dBContext.SaveChangesAsync();
        }
    }
}
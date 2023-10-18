using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskSystemsV2.Models;
using TaskSystemsV2.Repositories.Interfaces;

namespace TaskSystemsV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        [HttpGet("{id}")]
        public async Task<UserModel> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);
        }

        [HttpPost]
        public async Task<UserModel> InsertUser([FromBody] UserModel user)
        {
            return await _userRepository.InsertUser(user);
        }

        [HttpPut("{id}")]
        public async Task<UserModel> UpdateUser([FromBody] UserModel user, int id)
        {
            return await _userRepository.UpdateUser(user, id);
        }

        [HttpDelete("{id}")]
        public async Task DeleteUser(int id)
        {
            await _userRepository.DeleteUser(id);
        }
    }
}
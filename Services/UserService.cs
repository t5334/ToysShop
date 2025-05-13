using Entities;
using Reposirories;
using System.Text.Json;


namespace Services
{
    public class UserService : IUserService
    {
        public string filePath = "M:\\web-api\\user.txt";
        IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository=userRepository;
        }
        public async Task<User> register(User user)
        {
            if (passwordPower(user.Password) != -1)
            {
                return await _userRepository.register(user);
            }
            return null;
        }
        public async Task<User> login(User user)
        {

            return await _userRepository.login(user);
        }
        public async Task<User> updateUser(int id, User userToUpdate)
        {
            return await _userRepository.updateUser(id, userToUpdate);
        }
        public int passwordPower(string password)
        {
            if (password == null)
            {
                return -1;

            }

            int res = Zxcvbn.Core.EvaluatePassword(password).Score;
            return res;
        }
    }
}
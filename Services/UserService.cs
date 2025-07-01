using Entities;
using Reposirories;
using System.Text.Json;


namespace Services
{
    public class UserService : IUserService
    {
        public string filePath = "M:\\web-api\\user.txt";//
        IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository=userRepository;
        }
        public async Task<User> register(User user)//Register
        {
            if (passwordPower(user.Password) != -1)//check if password is strong enough
            {
                return await _userRepository.register(user);
            }
            return null;
        }
        public async Task<User> login(User user)//Login
        {

            return await _userRepository.login(user);
        }
        public async Task<User> updateUser(int id, User userToUpdate)//UpdateUser
        {
            return await _userRepository.updateUser(id, userToUpdate);//also here you can check if password is strong enough
        }
        public int passwordPower(string password)//PasswordPower
        {
            if (password == null)
            {
                return -1;

            }

            return Zxcvbn.Core.EvaluatePassword(password).Score;
        }
    }
}
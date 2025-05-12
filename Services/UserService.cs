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
        public User register(User user)
        {
            if (passwordPower(user.password) != -1)
            {
                return _userRepository.register(user);
            }
            return null;
        }
        public User login(User user)
        {

            return _userRepository.login(user);
        }
        public User updateUser(int id, User userToUpdate)
        {
            return _userRepository.updateUser(id, userToUpdate);
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
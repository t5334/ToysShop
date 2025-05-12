using Entities;
using Reposirories;
using System.Text.Json;


namespace Services
{
    public class UserService
    {
        public string filePath = "M:\\web-api\\user.txt";
        UserRepository userRepository = new UserRepository();
        public User register(User user)
        {
            return userRepository.register(user);
        }
        public User login(User user)
        {
            return userRepository.login(user);
        }
        public User updateUser(int id, User userToUpdate)
        {
          return userRepository.updateUser(id, userToUpdate);
        }
    }
}

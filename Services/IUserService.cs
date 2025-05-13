using Entities;

namespace Services
{
    public interface IUserService
    {
        Task<User> login(User user);
        int passwordPower(string password);
        Task<User> register(User user);
        Task<User> updateUser(int id, User userToUpdate);
    }
}
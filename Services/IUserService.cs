using Entities;

namespace Services
{
    public interface IUserService
    {
        User login(User user);
        int passwordPower(string password);
        User register(User user);
        User updateUser(int id, User userToUpdate);
    }
}
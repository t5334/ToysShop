using Entities;

namespace Reposirories
{
    public interface IUserRepository
    {
        User login(User user);
        User register(User user);
        User updateUser(int id, User userToUpdate);
    }
}
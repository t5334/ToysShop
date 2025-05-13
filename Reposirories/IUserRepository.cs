using Entities;

namespace Reposirories
{
    public interface IUserRepository
    {
        Task<User> login(User user);
        Task<User> register(User user);
        Task<User> updateUser(int id, User userToUpdate);
    }
}
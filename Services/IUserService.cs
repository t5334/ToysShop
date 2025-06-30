using Entities;
using DTO;
namespace Services
{
    public interface IUserService
    {
        Task<UserDTO> login(User user);
        int passwordPower(string password);
        Task<UserDTO> register(User user);
        Task<UserDTO> updateUser(int id, UserDTO userToUpdate);
    }
}
using System.Text.Json;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
namespace Reposirories
{
    public class UserRepository : IUserRepository
    {
        ToysContext _toysContext;
        public UserRepository(ToysContext toysContext)
        {
            _toysContext = toysContext;
        }
        public string filePath = "M:\\web-api\\user.txt";
        public async  Task<User> register(User user)
        {
            await _toysContext.Users.AddAsync(user);
            await _toysContext.SaveChangesAsync();
            return user;
        }
        public async Task<User> login(User user)
        {
           return  await _toysContext.Users.Where(u =>  u.UserName == user.UserName && u.Password == user.Password).FirstOrDefaultAsync();
        }
        public async Task<User> updateUser(int id, User userToUpdate)
        {
            _toysContext.Users.Update(userToUpdate);
            await _toysContext.SaveChangesAsync();
            return userToUpdate;
        }
    }
}

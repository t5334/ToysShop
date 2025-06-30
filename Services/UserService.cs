using Entities;
using Reposirories;
using System.Text.Json;
using DTO;
using AutoMapper;


namespace Services
{
    public class UserService : IUserService
    {
        public string filePath = "M:\\web-api\\user.txt";
        IUserRepository _userRepository;
        IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserDTO> register(User user)
        {
            if (passwordPower(user.Password) != -1)
            {
                User user1= await _userRepository.register(user);
                return _mapper.Map<UserDTO>(user1);
            }
            return null;
        }
        public async Task<UserDTO> login(User user)
        {

            User user1= await _userRepository.login(user);
            return _mapper.Map<UserDTO>(user1);
        }
        public async Task<UserDTO> updateUser(int id, UserDTO userToUpdate)
        {
            User user1=_mapper.Map<User>(userToUpdate);
            User user= await _userRepository.updateUser(id, user1);
            return _mapper.Map<UserDTO>(user);
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
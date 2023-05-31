using GenL.Business.Services.Abstract;
using GenL.DataAccess.Repositories.Abstract;
using GenL.DataAccess.Entities;

namespace GenL.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserEntity[]> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<UserEntity> GetAsync(string id)
        {
            return await _userRepository.GetAsync(id);
        }
    }
}
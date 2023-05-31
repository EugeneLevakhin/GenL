using GenL.DataAccess.Entities;

namespace GenL.DataAccess.Repositories.Abstract
{
    public interface IUserRepository
    {
        Task<UserEntity[]> GetAllAsync();
        Task<UserEntity> GetAsync(string id);
    }
}
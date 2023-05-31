using GenL.DataAccess.Entities;

namespace GenL.Business.Services.Abstract
{
    public interface IUserService
    {
        Task<UserEntity[]> GetAllAsync();
        Task<UserEntity> GetAsync(string id);
    }
}
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GenL.DataAccess.Entities;
using GenL.DataAccess.Repositories.Abstract;

namespace GenL.DataAccess.Repositories
{
    public class UserRepository : Repository<IdentityUser>, IUserRepository
    {
        public UserRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }

        public async Task<UserEntity[]> GetAllAsync()
        {
            return await DbContext.Users.ToArrayAsync();
        }

        public async Task<UserEntity> GetAsync(string id)
        {
            return await DbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
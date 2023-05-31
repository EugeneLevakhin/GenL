namespace GenL.DataAccess.Repositories
{
    public abstract class Repository<TEntity>
    {
        public ApplicationDbContext DbContext { get; set; }

        public Repository(ApplicationDbContext applicationDbContext)
        {
            DbContext = applicationDbContext;
        }

        public async Task<bool> AddAsync(TEntity entity)
        {
            await DbContext.AddAsync(entity);
            DbContext.SaveChanges();

            return true;
        }
    }
}
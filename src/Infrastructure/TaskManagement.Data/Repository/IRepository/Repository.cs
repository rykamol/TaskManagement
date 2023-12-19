using Microsoft.EntityFrameworkCore;

namespace TaskManagement.Data.Repository.IRepository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly TaskManagerDbContext _context;
        internal DbSet<T> dbSet;

        public Repository(TaskManagerDbContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }

        public void Create(T entity)
        {
            try
            {
                dbSet.Add(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public T GetById(int id)
        {
            return dbSet.Find(id);
        }     

        public void Delete(T entity)
        {
            try
            {
                dbSet.Remove(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> alltasks = dbSet;

            try
            {                                               
                return alltasks;
            }
            catch (Exception)
            {

                throw;
            }

        }     
    }
}

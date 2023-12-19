namespace TaskManagement.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {    
        void Create(T entity);

        T GetById(int id);

        void Delete(T entity);

        IEnumerable<T> GetAll();
    }
}

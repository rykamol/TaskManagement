using TaskManagement.Data.Repository.IRepository;
namespace TaskManagement.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private TaskManagerDbContext _db;

        public UnitOfWork(TaskManagerDbContext db)
        {
            _db = db;
            TaskRepo = new TaskRepository(_db);
        }

        public ITaskRepository TaskRepo { get; private set; }

        void IUnitOfWork.SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}

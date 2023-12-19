namespace TaskManagement.Data.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ITaskRepository TaskRepo { get; }

        void SaveChanges();
    }
}

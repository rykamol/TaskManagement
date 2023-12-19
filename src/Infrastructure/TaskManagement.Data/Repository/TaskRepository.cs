using Microsoft.EntityFrameworkCore;
using TaskManagement.Data.Repository.IRepository;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Data.Repository
{
    public class TaskRepository : Repository<TaskModel>, ITaskRepository
    {
        private TaskManagerDbContext _context;
        public TaskRepository(TaskManagerDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(TaskModel model)
        {
            _context.Entry(model).State = EntityState.Detached;
            _context.Set<TaskModel>().Update(model);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Data.Repository.IRepository
{
    public interface ITaskRepository : IRepository<TaskModel>
    {
        void Update(TaskModel entity);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;

namespace TaskManagerTest.MockData
{
    internal class TaskMockData
    {
        public static List<TaskModel> GetAllTasks()
        {
            return new List<TaskModel>()
            {
                new TaskModel()
                {
                    Id = 1,
                    Title = "Test",
                    Status="Pending",
                    Description="Test Description",
                    DueDate= DateTime.Now,
                },
                new TaskModel()
                {
                    Id = 2,
                    Title = "Test2",
                    Status="Pending2",
                    Description="Test Description2",
                    DueDate= DateTime.Now,
                },
                 new TaskModel()
                {
                    Id = 3,
                    Title = "Test3",
                    Status="Pending3",
                    Description="Test Description3",
                    DueDate= DateTime.Now,
                },

            };
        }
        public static List<TaskModel> GetEmptyTasks()
        {
            return new List<TaskModel>();
        }

        public static  TaskModel GetValidTask()
        {
            return new TaskModel
            {
                Id= 0,
                Title = "Demo Task",
                Status = "Pending",
                Description = "Test Description",
                DueDate = DateTime.Now,
            };
        }

        public static TaskModel GetInvalidTask()
        {
            return new TaskModel
            {
                Title = "",
                Status = "Pending",
                Description = "Test Description",
                DueDate = DateTime.Now,
            };
        }

        
    }
}

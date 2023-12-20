using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using TaskManagement.Data;
using TaskManagement.Data.Repository;
using TaskManagement.Data.Repository.IRepository;
using TaskManagement.Domain.Entities;
using TaskManagerTest.MockData;
using Template.Api.Controllers;

namespace TaskManagerTest
{
    public class TestTaskRepository : IDisposable
    {
        private readonly TaskManagerDbContext _db;

        public TestTaskRepository()
        {
            //Create in memory db
            var options = new DbContextOptionsBuilder<TaskManagerDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            _db = new TaskManagerDbContext(options);
            _db.Database.EnsureCreated();

        }

        [Fact]
        public async Task GetAll_ShouldReturnCollection()
        {
            //Arrange
            _db.TblTask.AddRange(TaskMockData.GetAllTasks());
            _db.SaveChanges();
            var sut = new TaskRepository(_db);

            //Act
            var result = sut.GetAll();

            //Assert
            result.Should().HaveCount(TaskMockData.GetAllTasks().Count);
        }

        public void Dispose()
        {
            _db.Database.EnsureDeleted();
            _db.Dispose();
        }


    }
}
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TaskManagement.Data.Repository.IRepository;
using TaskManagement.Domain.Entities;
using TaskManagerTest.MockData;
using Template.Api.Controllers;

namespace TaskManagerTest
{
    public class TestTaskController
    {
        [Fact]
        public async Task GetAllTasks_ShouldReturnOkStatus()
        {
            //Arrange
            var _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(_ => _.TaskRepo.GetAll()).Returns(TaskMockData.GetAllTasks());
            var sut = new TaskController(_unitOfWork.Object);

            //Act
            var result = await sut.GetAllTasks();

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }


        [Fact]
        public async Task GetAllTasks_ShouldReturn204Status()
        {
            //Arrange
            var _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(_ => _.TaskRepo.GetAll()).Returns(TaskMockData.GetEmptyTasks());
            var sut = new TaskController(_unitOfWork.Object);

            //Act
            var result = await sut.GetAllTasks();

            //Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }


        [Fact]
        public async Task CreateTasks_ShouldReturn200Status()
        {
            //Arrange
            var _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(_ => _.TaskRepo.Create(TaskMockData.GetValidTask()));
            var sut = new TaskController(_unitOfWork.Object);

            //Act
            var result = await sut.Create(TaskMockData.GetValidTask());

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }


        [Fact]
        public async Task CreateTasks_ShouldReturn400Status()
        {
            //Arrange
            var _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(_ => _.TaskRepo.Create(TaskMockData.GetInvalidTask()));
            var sut = new TaskController(_unitOfWork.Object);

            //Act
            var result = await sut.Create(TaskMockData.GetInvalidTask());

            //Assert
            result.GetType().Should().Be(typeof(BadRequestObjectResult));
            (result as BadRequestObjectResult).StatusCode.Should().Be(400);
        }


        [Fact]
        public async Task UpdateTasks_ShouldReturn200Status()
        {
            //Arrange
            var _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(_ => _.TaskRepo.Update(TaskMockData.GetValidTask()));
            _unitOfWork.Setup(_ => _.TaskRepo.GetById(0)).Returns(TaskMockData.GetValidTask());
            var sut = new TaskController(_unitOfWork.Object);

            //Act
            var result = await sut.Update(TaskMockData.GetValidTask());

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task UpdateTasks_ShouldReturn400Status()
        {
            //Arrange
            var _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(_ => _.TaskRepo.Update(TaskMockData.GetValidTask()));
            _unitOfWork.Setup(_ => _.TaskRepo.GetById(0)).Returns(null as TaskModel);
            var sut = new TaskController(_unitOfWork.Object);

            //Act
            var result = await sut.Update(TaskMockData.GetValidTask());

            //Assert
            result.GetType().Should().Be(typeof(NotFoundObjectResult));
            (result as NotFoundObjectResult).StatusCode.Should().Be(404);
        }


        [Fact]
        public async Task DeleteTasks_ShouldReturn200Status()
        {
            //Arrange
            var _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(_ => _.TaskRepo.Delete(TaskMockData.GetValidTask()));
            _unitOfWork.Setup(_ => _.TaskRepo.GetById(0)).Returns(TaskMockData.GetValidTask());
            var sut = new TaskController(_unitOfWork.Object);

            //Act
            var result = await sut.Delete(0);

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }


        [Fact]
        public async Task DeleteTasks_ShouldReturn400Status()
        {
            //Arrange
            var _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(_ => _.TaskRepo.Delete(TaskMockData.GetValidTask()));
            _unitOfWork.Setup(_ => _.TaskRepo.GetById(0)).Returns(null as TaskModel);
            var sut = new TaskController(_unitOfWork.Object);

            //Act
            var result = await sut.Delete(0);

            //Assert
            result.GetType().Should().Be(typeof(NotFoundObjectResult));
            (result as NotFoundObjectResult).StatusCode.Should().Be(404);
        }


        [Fact]
        public async Task GetByIdTasks_ShouldReturn200Status()
        {
            //Arrange
            var _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(_ => _.TaskRepo.GetById(0)).Returns(TaskMockData.GetValidTask());
            var sut = new TaskController(_unitOfWork.Object);

            //Act
            var result = await sut.GetById(0);

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }


        [Fact]
        public async Task GetByIdTasks_ShouldReturn404Status()
        {
            //ArrangeF
            var _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(_ => _.TaskRepo.GetById(0)).Returns(null as TaskModel);
            var sut = new TaskController(_unitOfWork.Object);

            //Act
            var result = await sut.GetById(0);

            //Assert
            result.GetType().Should().Be(typeof(NotFoundObjectResult));
            (result as NotFoundObjectResult).StatusCode.Should().Be(404);
        }


        [Fact]
        public async Task Create_ShouldCallSaveChangesOnce()
        {
            //Arrange
            var _unitOfWork = new Mock<IUnitOfWork>();
            var newTask = TaskMockData.GetValidTask();
            _unitOfWork.Setup(_ => _.TaskRepo.Create(newTask));
            var sut = new TaskController(_unitOfWork.Object);

            //Act
            var result = sut.Create(newTask);

            //Assert
            _unitOfWork.Verify(_ => _.SaveChanges(), Times.Exactly(1));
        }


    }
}
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Data.Repository.IRepository;
using TaskManagement.Domain.Entities;

namespace Template.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public TaskController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(TaskModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if(string.IsNullOrEmpty(model.Title)) { return BadRequest("Title is empty!"); }
            try
            {
                var task = new TaskModel()
                {
                    Title = model.Title,
                    Description = model.Description,
                    Status = model.Status,
                    DueDate = model.DueDate
                };

                _unitOfWork.TaskRepo.Create(task);
                _unitOfWork.SaveChanges();

                return Ok(task);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // return BadRequest(ex.Message);
            }
        }


        [HttpPost("Update")]
        public async Task<IActionResult> Update(TaskModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var taskToUpdate = _unitOfWork.TaskRepo.GetById(model.Id);
            if (taskToUpdate == null)
                return NotFound("Task not found!");

            try
            {
                taskToUpdate.Title = model.Title;
                taskToUpdate.Description = model.Description;
                taskToUpdate.Status = model.Status;
                taskToUpdate.DueDate = model.DueDate;

                _unitOfWork.TaskRepo.Update(taskToUpdate);
                _unitOfWork.SaveChanges();
                return Ok(taskToUpdate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // return BadRequest(ex.Message);
            }
        }


        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var taskToDelete = _unitOfWork.TaskRepo.GetById(id);

            if (taskToDelete == null)
                return NotFound("Task not found!");

            try
            {
                _unitOfWork.TaskRepo.Delete(taskToDelete);
                _unitOfWork.SaveChanges();
                return Ok("Item Deleted Successful!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var taskToReturn = _unitOfWork.TaskRepo.GetById(id);

            if (taskToReturn == null)
                return NotFound("Task not found!");

            try
            {
                return Ok(taskToReturn);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllTasks()
        {
            try
            {
                var tasks = _unitOfWork.TaskRepo.GetAll().ToList();

                if (tasks.Count == 0)
                {
                    return NoContent();
                }

                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // return BadRequest(ex.Message);
            }
        }
    };
}
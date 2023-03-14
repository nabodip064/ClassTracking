using ClassTracking.Domain.Interfaces;
using ClassTracking.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClassTracking.Server.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeacherController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var teachers = await _unitOfWork.Teachers.GetAll();
                if (teachers == null)
                    return NotFound();
                return Ok(teachers);
            }
            catch
            {
                return BadRequest("Internal Server Error Occurred");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var teachers = await _unitOfWork.Teachers.GetById(id);
                if (teachers == null)
                    return NotFound();
                return Ok(teachers);
            }
            catch
            {
                return BadRequest("Internal Server Error Occurred");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(Teacher teacher)
        {
            try
            {
                await _unitOfWork.Teachers.Add(teacher);
                await _unitOfWork.Complete();
                return Ok();
            }
            catch
            {
                return BadRequest("Internal Server Error Occurred");
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(Teacher teacher)
        {
            try
            {
                if (teacher == null)
                    return BadRequest("Teacher can't be empty");
                else
                {
                    Teacher existingTeacher = await _unitOfWork.Teachers.GetById(teacher.Id);
                    if (existingTeacher == null)
                        return BadRequest("Teacher can't be empty");
                    existingTeacher.Name = teacher.Name;
                    existingTeacher.Designation = teacher.Designation;
                    existingTeacher.JoiningDate = teacher.JoiningDate;
                    await _unitOfWork.Complete();
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Internal Server Error Occurred");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Teacher existingTeacher = await _unitOfWork.Teachers.GetById(id);
                if (existingTeacher == null)
                    return BadRequest("Teacher can't be empty");
                _unitOfWork.Teachers.Remove(existingTeacher);
                await _unitOfWork.Complete();
                return Ok();

            }
            catch
            {
                return BadRequest("Internal Server Error Occurred");
            }
        }
    }
}

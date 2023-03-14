using ClassTracking.Domain.Interfaces;
using ClassTracking.Shared;
using ClassTracking.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClassTracking.Server.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                string[] includes = { "Class" };
                var students = await _unitOfWork.Students.GetAllWithInclude(includes);
                if (students == null)
                    return NotFound();
                return Ok(students);
            }
            catch(Exception ex)
            {
                return BadRequest("Internal Server Error Occurred");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var student = await _unitOfWork.Students.GetById(id);
                if (student == null)
                    return NotFound();
                return Ok(student);
            }
            catch
            {
                return BadRequest("Internal Server Error Occurred");
            }
        }
        [HttpGet("class/{classId:int}")]
        public async Task<IActionResult> GetByStudentByClass(int classId)
        {
            try
            {
                var students = await _unitOfWork.Students.Find(s => s.ClassId == classId);
                if (students == null)
                    return NotFound();
                return Ok(students);
            }
            catch
            {
                return BadRequest("Internal Server Error Occurred");
            }
        }
        [HttpGet("applicable-in-class/{classId:int}")]
        public async Task<IActionResult> CheckAssignedTeacher(int classId)
        {
            try
            {
                bool applicable = true;
                var allStudents = await _unitOfWork.Students.Find(s => s.ClassId == classId);
                var classStandard = await _unitOfWork.ClassStandards.GetById(classId);
                if (classStandard != null)
                {
                    if(classStandard.MaxStudent != null)
                        applicable = classStandard.MaxStudent > allStudents.Count();
                }
                return Ok(applicable);
            }
            catch
            {
                return BadRequest("Internal Server Error Occurred");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            try
            {
                await _unitOfWork.Students.Add(student);
                await _unitOfWork.Complete();
                return Ok();
            }
            catch
            {
                return BadRequest("Internal Server Error Occurred");
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(Student student)
        {
            try
            {
                if (student == null)
                    return BadRequest("Student can't be empty");
                else
                {
                    Student existingStudent = await _unitOfWork.Students.GetById(student.Id);
                    if (existingStudent == null)
                        return BadRequest("Student can't be empty");
                    existingStudent.Name = student.Name;
                    existingStudent.FatherName = student.FatherName;
                    existingStudent.MotherName = student.MotherName;
                    existingStudent.Nationality = student.Nationality;
                    existingStudent.DateOfBirth = student.DateOfBirth;
                    existingStudent.ClassId = student.ClassId;
                    existingStudent.EnrollDate = student.EnrollDate;
                    await _unitOfWork.Complete();
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Student existingStudent = await _unitOfWork.Students.GetById(id);
                if (existingStudent == null)
                    return BadRequest("Student can't be empty");
                _unitOfWork.Students.Remove(existingStudent);
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

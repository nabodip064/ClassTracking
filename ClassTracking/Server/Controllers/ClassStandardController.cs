using ClassTracking.Domain.Interfaces;
using ClassTracking.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClassTracking.Server.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ClassStandardController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClassStandardController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                string[] includes = { "Teacher" };
                var classStandards = await _unitOfWork.ClassStandards.GetAllWithInclude(includes);
                if (classStandards == null)
                    return NotFound();
                foreach (var classStandard in classStandards)
                {
                    classStandard.TotalStudent = (await _unitOfWork.Students.Find(s => s.ClassId == classStandard.Id)).Count();
                }
                return Ok(classStandards);
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
                var classStandard = await _unitOfWork.ClassStandards.GetById(id);
                if (classStandard == null)
                    return NotFound();
                return Ok(classStandard);
            }
            catch
            {
                return BadRequest("Internal Server Error Occurred");
            }
        }
        [HttpGet("exist-teacher/{teacherId:int}/{classId:int}")]
        public async Task<IActionResult> CheckAssignedTeacher(int teacherId, int classId)
        {
            try
            {
                bool result = await _unitOfWork.ClassStandards.HasClassStandardByTeacherAsync(teacherId, classId);
                return Ok(result);
            }
            catch
            {
                return BadRequest("Internal Server Error Occurred");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(ClassStandard classStandard)
        {
            try
            {
                await _unitOfWork.ClassStandards.Add(classStandard);
                await _unitOfWork.Complete();
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest("Internal Server Error Occurred");
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(ClassStandard classStandard)
        {
            try
            {
                if (classStandard == null)
                    return BadRequest("ClassStandard can't be empty");
                else
                {
                    ClassStandard existingClassStandard = await _unitOfWork.ClassStandards.GetById(classStandard.Id);
                    if (existingClassStandard == null)
                        return BadRequest("ClassStandard can't be empty");
                    existingClassStandard.Name = classStandard.Name;
                    existingClassStandard.Description = classStandard.Description;
                    existingClassStandard.Standard = classStandard.Standard;
                    existingClassStandard.SessionYear = classStandard.SessionYear;
                    existingClassStandard.MaxStudent = classStandard.MaxStudent;
                    existingClassStandard.TeacherId = classStandard.TeacherId;
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
                ClassStandard existingClassStandard = await _unitOfWork.ClassStandards.GetById(id);
                if (existingClassStandard == null)
                    return BadRequest("ClassStandard can't be empty");
                _unitOfWork.ClassStandards.Remove(existingClassStandard);
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

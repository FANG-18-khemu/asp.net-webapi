using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using day2.Models;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace day2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentModel obj;

        public StudentController()
        {
            obj = new StudentModel();
        }

        [HttpGet]
        [Route("/student/all")]
        public IActionResult GetAllStudent()
        {
            return Ok(obj.GetAllStudents());
        }

        [HttpGet]
        [Route("/student/id/{id}")]
        public IActionResult GetStudent(int id)
        {
            try
            {
                var student = obj.GetStudentById(id);
                return Ok(student);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/student/name/{name}")]
        public IActionResult StudentDetailByName(string name)
        {
            try
            {
                var student = obj.GetStudentByName(name);
                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/student/add")]
        public IActionResult AddStudent([FromBody]StudentModel student)
        {
            return Created("",obj.addStudent(student));
        }

        [HttpPut]
        [Route("/student/update/{id}")]
        public IActionResult UpdateStudent(int id, [FromBody]StudentModel student)
        {
            var val = obj.updateStudent(id,student);
            return Accepted(val);
        }

        [HttpDelete]
        [Route("/student/Deleteid/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                string val = obj.removeStudent(id);
                return Accepted(val);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

using AspCoreWebApi___CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;


namespace AspCoreWebApi___CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : Controller
    {
        private readonly StudentDBContext studentDB;

        public StudentAPIController(StudentDBContext studentDB)
        {
            this.studentDB = studentDB;
        }
        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            await studentDB.tblStudents.AddAsync(student);
            await studentDB.SaveChangesAsync();
            return Ok(student);
        }
        [HttpPut("id")]
        public async Task<ActionResult<Student>> UpdateStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }
            studentDB.Entry(student).State = EntityState.Modified;
            await studentDB.SaveChangesAsync();
            return Ok(student);
        }
        [HttpDelete("id")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var std = await studentDB.tblStudents.FindAsync(id);
            if (std == null)
            {
                return NotFound();
            }
            studentDB.tblStudents.Remove(std);
            await studentDB.SaveChangesAsync();
            return Ok(std);
        }
        [HttpGet("id")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var student = await studentDB.tblStudents.FindAsync(id);
            if (student == null)
            { return NotFound(); 
            }
            return student;


        }
        
    }
}

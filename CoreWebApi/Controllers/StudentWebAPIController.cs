using CoreWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentWebAPIController : ControllerBase
    {
        private readonly StudentContext db;

        public StudentWebAPIController(StudentContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<ActionResult<Student>> GetStudents()
        {
            var data = await db.Students.ToListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var student= await db.Students.FindAsync(id);
            if(student == null)
            {
                return NotFound();
            }
            return student;
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student stud)
        {
            await db.Students.AddAsync(stud);
            await db.SaveChangesAsync();
            return Ok(stud);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> UpdateStudent(Student stud,int id)
        {
            if (id != stud.Id)
            {
                return BadRequest();
            }
            db.Entry(stud).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return Ok(stud);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var stud = await db.Students.FindAsync(id);

            if(stud == null)
            { return NotFound(); }

            db.Students.Remove(stud);
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}

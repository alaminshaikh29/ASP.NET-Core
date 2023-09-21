using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentFrom.DAL;
using StudentFrom.Models;

namespace StudentFrom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbContext _context;//field
        public StudentController(StudentDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Student>> Get()
        {
            return await _context.Students.ToListAsync();
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Get(long id)
        {
            if (id < 1)
                return BadRequest();
            var student = await _context.Students.FirstOrDefaultAsync(model => model.Id == id);
            if (student == null)
                return NotFound();
            return Ok(student);
        }



        //Create or Post

        [HttpPost]
        public async Task<IActionResult> Post(Student student)
        {
            _context.Add(student);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //Delete

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            if (id < 1)
                return BadRequest();
            var student = await _context.Students.FindAsync(id);
            if (student == null)

                return NotFound();
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return Ok();
        }


        //PUT OR EDIT
        [HttpPut]
        public async Task<IActionResult> Put(Student studentData)
        {
            if (studentData == null || studentData.Id == 0)
                return BadRequest();

            var student = await _context.Students.FindAsync(studentData.Id);
            if (student == null)
                return NotFound();

            student.Name = studentData.Name;
            student.Email = studentData.Email;
            student.Phone = studentData.Phone;
            student.Address = studentData.Address;
            await _context.SaveChangesAsync();
            return Ok();
        }


    }
}
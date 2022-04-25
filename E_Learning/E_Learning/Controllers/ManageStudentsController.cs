#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_Learning.DataContext;
using E_Learning.Model;
using Microsoft.AspNetCore.Authorization;

namespace E_Learning.Controllers
{
    [Authorize(Roles = "Admin,Teacher,BanGiamHieu")]
    [Route("api/[controller]")]
    [ApiController]
    public class ManageStudentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ManageStudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ManageStudents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManageStudent>>> GetManageStudent()
        {
            return await _context.ManageStudent.ToListAsync();
        }

        // GET: api/ManageStudents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ManageStudent>> GetManageStudent(int id)
        {
            var manageStudent = await _context.ManageStudent.FindAsync(id);

            if (manageStudent == null)
            {
                return NotFound();
            }

            return manageStudent;
        }

        // PUT: api/ManageStudents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManageStudent(int id, ManageStudent manageStudent)
        {
            if (id != manageStudent.MaStudent)
            {
                return BadRequest();
            }

            _context.Entry(manageStudent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManageStudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ManageStudents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ManageStudent>> PostManageStudent(ManageStudent manageStudent)
        {
            _context.ManageStudent.Add(manageStudent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetManageStudent", new { id = manageStudent.MaStudent }, manageStudent);
        }

        // DELETE: api/ManageStudents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManageStudent(int id)
        {
            var manageStudent = await _context.ManageStudent.FindAsync(id);
            if (manageStudent == null)
            {
                return NotFound();
            }

            _context.ManageStudent.Remove(manageStudent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ManageStudentExists(int id)
        {
            return _context.ManageStudent.Any(e => e.MaStudent == id);
        }
    }
}

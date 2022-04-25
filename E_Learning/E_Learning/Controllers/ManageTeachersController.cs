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
    [Authorize(Roles = "Admin, BanGiamHieu")]
    [Route("api/[controller]")]
    [ApiController]
    public class ManageTeachersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ManageTeachersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ManageTeachers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManageTeacher>>> GetManageTeacher()
        {
            return await _context.ManageTeacher.ToListAsync();
        }

        // GET: api/ManageTeachers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ManageTeacher>> GetManageTeacher(int id)
        {
            var manageTeacher = await _context.ManageTeacher.FindAsync(id);

            if (manageTeacher == null)
            {
                return NotFound();
            }

            return manageTeacher;
        }

        // PUT: api/ManageTeachers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManageTeacher(int id, ManageTeacher manageTeacher)
        {
            if (id != manageTeacher.MaTeacher)
            {
                return BadRequest();
            }

            _context.Entry(manageTeacher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManageTeacherExists(id))
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

        // POST: api/ManageTeachers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ManageTeacher>> PostManageTeacher(ManageTeacher manageTeacher)
        {
            _context.ManageTeacher.Add(manageTeacher);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetManageTeacher", new { id = manageTeacher.MaTeacher }, manageTeacher);
        }

        // DELETE: api/ManageTeachers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManageTeacher(int id)
        {
            var manageTeacher = await _context.ManageTeacher.FindAsync(id);
            if (manageTeacher == null)
            {
                return NotFound();
            }

            _context.ManageTeacher.Remove(manageTeacher);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ManageTeacherExists(int id)
        {
            return _context.ManageTeacher.Any(e => e.MaTeacher == id);
        }
    }
}

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
    [Authorize(Roles = "Admin, Teacher, Student,BanGiamHieu")]
    [Route("api/[controller]")]
    [ApiController]
    public class ManageLearningsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ManageLearningsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ManageLearnings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManageLearning>>> GetManageLearning()
        {
            return await _context.ManageLearning.ToListAsync();
        }

        // GET: api/ManageLearnings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ManageLearning>> GetManageLearning(int id)
        {
            var manageLearning = await _context.ManageLearning.FindAsync(id);

            if (manageLearning == null)
            {
                return NotFound();
            }

            return manageLearning;
        }

        // PUT: api/ManageLearnings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManageLearning(int id, ManageLearning manageLearning)
        {
            if (id != manageLearning.Ma_KhoaHoc)
            {
                return BadRequest();
            }

            _context.Entry(manageLearning).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManageLearningExists(id))
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

        // POST: api/ManageLearnings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ManageLearning>> PostManageLearning(ManageLearning manageLearning)
        {
            _context.ManageLearning.Add(manageLearning);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetManageLearning", new { id = manageLearning.Ma_KhoaHoc }, manageLearning);
        }

        // DELETE: api/ManageLearnings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManageLearning(Guid id)
        {
            var manageLearning = await _context.ManageLearning.FindAsync(id);
            if (manageLearning == null)
            {
                return NotFound();
            }

            _context.ManageLearning.Remove(manageLearning);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ManageLearningExists(int id)
        {
            return _context.ManageLearning.Any(e => e.Ma_KhoaHoc == id);
        }
    }
}

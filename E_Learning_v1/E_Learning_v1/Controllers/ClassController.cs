using E_Learning_v1.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClassController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Class>>> GetClass()
        {
            return Ok(await _context.Class.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Class>>> PostClass(Class @class)
        {
            _context.Class.Add(@class);
            await _context.SaveChangesAsync();
            return Ok(await _context.Class.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Class>>> UpdateClass(Class @class)
        {
            var dbClass = await _context.Class.FindAsync(@class.MaLop);
            if (dbClass == null)
                return BadRequest("Lớp không Tồn Tại");
            dbClass.MonHoc= @class.MonHoc;
            dbClass.ThoiGian=@class.ThoiGian;
            dbClass.TrangThai=@class.TrangThai;
            await _context.SaveChangesAsync();
            return Ok(await _context.Class.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Class>>> DeleteClass(int id)
        {
            var dbClass = await _context.Class.FindAsync(id);
            if (dbClass == null)
                return BadRequest("Lớp không tồn tại");
            _context.Class.Remove(dbClass);
            await _context.SaveChangesAsync();
            return Ok(await _context.Class.ToListAsync());
        }
    }
}

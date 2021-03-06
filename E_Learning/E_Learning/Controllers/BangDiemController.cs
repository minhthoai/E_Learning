using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using E_Learning.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace E_Learning.Controllers
{
    [Authorize(Roles = "Admin,Teacher,BanGiamHieu")]
    [Route("api/[controller]")]
    [ApiController]
    public class BangDiemController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BangDiemController(ApplicationDbContext context)
        {
            _context = context;
        }
        //[Authorize (Roles ="Student")]
        [HttpGet]
        public async Task<ActionResult<List<BangDiem>>> GetBangDiem()
        {
            return Ok(await _context.BangDiem.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<BangDiem>>> PostBangDiem(BangDiem bangDiem)
        {
            _context.BangDiem.Add(bangDiem);
            await _context.SaveChangesAsync();
            return Ok(await _context.BangDiem.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<BangDiem>>> UpdateBangDiem(BangDiem bangDiem)
        {
            var dbBangDiem = await _context.BangDiem.FindAsync(bangDiem.MaBangDiem);
            if (dbBangDiem == null)
                return BadRequest("Scoreboard does not exist");
            dbBangDiem.TenHocSinh= bangDiem.TenHocSinh;
            dbBangDiem.NgaySinh= bangDiem.NgaySinh;
            dbBangDiem.ChuyenCan= bangDiem.ChuyenCan;
            dbBangDiem.DiemMieng= bangDiem.DiemMieng;
            dbBangDiem.HeSo1= bangDiem.HeSo1;
            dbBangDiem.HeSo2= bangDiem.HeSo2;
            dbBangDiem.DiemTrungBinh= bangDiem.DiemTrungBinh;
            dbBangDiem.DiemTrungBinhCaNam= bangDiem.DiemTrungBinhCaNam;
            dbBangDiem.TrangThai= bangDiem.TrangThai;
            dbBangDiem.NgayCapNhat= bangDiem.NgayCapNhat;
            await _context.SaveChangesAsync();
            return Ok(await _context.BangDiem.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<BangDiem>>> DeleteBangDiem(int id)
        {
            var dbBangDiem = await _context.BangDiem.FindAsync(id);
            if (dbBangDiem == null)
                return BadRequest("Scoreboard does not exist");
            _context.BangDiem.Remove(dbBangDiem);
            await _context.SaveChangesAsync();
            return Ok(await _context.BangDiem.ToListAsync());
        }
    }
}

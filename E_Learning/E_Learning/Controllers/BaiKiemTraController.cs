using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using E_Learning.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace E_Learning.Controllers
{
   [Authorize(Roles = "Admin,Teacher")]
    [Route("api/[controller]")]
    [ApiController]
    public class BaiKiemTraController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BaiKiemTraController(ApplicationDbContext context)
        {
            _context = context;
        }
       // [Authorize(Roles = "Admin,Teacher,Student")]
        [HttpGet]
        public async Task<ActionResult<List<BaiKiemTra>>> GetBaiKiemTra()
        {
            return Ok(await _context.BaiKiemTra.ToListAsync());
        }
      //  [Authorize(Roles = "Admin,Teacher")]
        [HttpPost]
        public async Task<ActionResult<List<BaiKiemTra>>> PostBaiKiemTra(BaiKiemTra baiKiemTra)
        {
            _context.BaiKiemTra.Add(baiKiemTra);
            await _context.SaveChangesAsync();
            return Ok(await _context.BaiKiemTra.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<BaiKiemTra>>> UpdateBaiKiemTra(BaiKiemTra baiKiemTra)
        {
            var dbBKT = await _context.BaiKiemTra.FindAsync(baiKiemTra.MaBaiKiemTra);
            if (dbBKT == null)
                return BadRequest("Test does not exist");
            dbBKT.Lop = baiKiemTra.Lop;
            dbBKT.NoiDungKiemTra= baiKiemTra.NoiDungKiemTra;
            dbBKT.MonHoc= baiKiemTra.MonHoc;
            dbBKT.NgayLamBai= baiKiemTra.NgayLamBai;
            dbBKT.ThoiLuong= baiKiemTra.ThoiLuong;
            dbBKT.TinhTrang= baiKiemTra.TinhTrang;
            await _context.SaveChangesAsync();
            return Ok(await _context.BaiKiemTra.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<BaiKiemTra>>> DeleteBaiKiemTra(int id)
        {
            var dbBKT = await _context.BaiKiemTra.FindAsync(id);
            if (dbBKT == null)
                return BadRequest("Test does not exist");
            _context.BaiKiemTra.Remove(dbBKT);
            await _context.SaveChangesAsync();
            return Ok(await _context.BaiKiemTra.ToListAsync());
        }
    }
}

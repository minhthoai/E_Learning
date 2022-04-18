using E_Learning_v1.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailClassController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DetailClassController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Detail_Class>>> GetDetail_Class()
        {
            return Ok(await _context.Detail_Class.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Detail_Class>>> PostDetail_Class(Detail_Class detail_Class)
        {
            _context.Detail_Class.Add(detail_Class);
            await _context.SaveChangesAsync();
            return Ok(await _context.Detail_Class.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Detail_Class>>> UpdateDetail_Class(Detail_Class detail_Class)
        {
            var dbDetail_Class = await _context.Detail_Class.FindAsync(detail_Class.MaLop);
            if (dbDetail_Class == null)
                return BadRequest("Chi tiết lớp không Tồn Tại");
            dbDetail_Class.TenGiaoVien = detail_Class.TenGiaoVien;
            dbDetail_Class.BoMon=detail_Class.BoMon;
            dbDetail_Class.MoTa=detail_Class.MoTa;
            dbDetail_Class.SoBuoi=detail_Class.SoBuoi;
            dbDetail_Class.ThoiLuong=detail_Class.ThoiLuong;
            dbDetail_Class.NgayBatDau=detail_Class.NgayBatDau;
            dbDetail_Class.NgayKetThuc=detail_Class.NgayKetThuc;
            await _context.SaveChangesAsync();
            return Ok(await _context.Detail_Class.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Detail_Class>>> DeleteDetail_Class (int id)
        {
            var dbDetail_Class = await _context.Detail_Class.FindAsync(id);
            if (dbDetail_Class == null)
                return BadRequest("Chi tiết lớp không tồn tại");
            _context.Detail_Class.Remove(dbDetail_Class);
            await _context.SaveChangesAsync();
            return Ok(await _context.Detail_Class.ToListAsync());
        }
    }
}

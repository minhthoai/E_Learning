#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_Learning_v1.DataContext;
using E_Learning_v1.Model;
using Microsoft.AspNetCore.Authorization;

namespace E_Learning_v1.Controllers
{
    [Authorize(Roles = "Admin,Teacher,Students")]
   //[Route("api/[controller]")]
   // [ApiController]
    public class BanGiamHieuxController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BanGiamHieuxController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BanGiamHieux
        public async Task<IActionResult> Index()
        {
            return View(await _context.BanGiamHieu.ToListAsync());
        }

        // GET: BanGiamHieux/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banGiamHieu = await _context.BanGiamHieu
                .FirstOrDefaultAsync(m => m.MaBGH == id);
            if (banGiamHieu == null)
            {
                return NotFound();
            }

            return View(banGiamHieu);
        }

        // GET: BanGiamHieux/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BanGiamHieux/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaBGH,TenBGH")] BanGiamHieu banGiamHieu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(banGiamHieu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(banGiamHieu);
        }

        // GET: BanGiamHieux/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banGiamHieu = await _context.BanGiamHieu.FindAsync(id);
            if (banGiamHieu == null)
            {
                return NotFound();
            }
            return View(banGiamHieu);
        }

        // POST: BanGiamHieux/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaBGH,TenBGH")] BanGiamHieu banGiamHieu)
        {
            if (id != banGiamHieu.MaBGH)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(banGiamHieu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BanGiamHieuExists(banGiamHieu.MaBGH))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(banGiamHieu);
        }

        // GET: BanGiamHieux/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banGiamHieu = await _context.BanGiamHieu
                .FirstOrDefaultAsync(m => m.MaBGH == id);
            if (banGiamHieu == null)
            {
                return NotFound();
            }

            return View(banGiamHieu);
        }

        // POST: BanGiamHieux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var banGiamHieu = await _context.BanGiamHieu.FindAsync(id);
            _context.BanGiamHieu.Remove(banGiamHieu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BanGiamHieuExists(int id)
        {
            return _context.BanGiamHieu.Any(e => e.MaBGH == id);
        }
    }
}

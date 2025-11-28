using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CookingWebsite.Data;
using CookingWebsite.Models;

namespace CookingWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class IngredientCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IngredientCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/IngredientCategories
        public async Task<IActionResult> Index()
        {
            var loaiNguyenLieus = await _context.LoaiNguyenLieus
                .OrderBy(l => l.TenLoai)
                .ToListAsync();

            return View(loaiNguyenLieus);
        }

        // GET: Admin/IngredientCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiNguyenLieu = await _context.LoaiNguyenLieus
                .Include(l => l.NguyenLieus)
                .FirstOrDefaultAsync(m => m.MaLoaiNguyenLieu == id);

            if (loaiNguyenLieu == null)
            {
                return NotFound();
            }

            return View(loaiNguyenLieu);
        }

        // GET: Admin/IngredientCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/IngredientCategories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LoaiNguyenLieu loaiNguyenLieu)
        {
            if (ModelState.IsValid)
            {
                // Get next MaLoaiNguyenLieu
                var maxId = await _context.LoaiNguyenLieus
                    .OrderByDescending(l => l.MaLoaiNguyenLieu)
                    .Select(l => l.MaLoaiNguyenLieu)
                    .FirstOrDefaultAsync();
                loaiNguyenLieu.MaLoaiNguyenLieu = maxId + 1;

                _context.Add(loaiNguyenLieu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loaiNguyenLieu);
        }

        // GET: Admin/IngredientCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiNguyenLieu = await _context.LoaiNguyenLieus.FindAsync(id);
            if (loaiNguyenLieu == null)
            {
                return NotFound();
            }

            return View(loaiNguyenLieu);
        }

        // POST: Admin/IngredientCategories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LoaiNguyenLieu loaiNguyenLieu)
        {
            if (id != loaiNguyenLieu.MaLoaiNguyenLieu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaiNguyenLieu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiNguyenLieuExists(loaiNguyenLieu.MaLoaiNguyenLieu))
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
            return View(loaiNguyenLieu);
        }

        // GET: Admin/IngredientCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiNguyenLieu = await _context.LoaiNguyenLieus
                .FirstOrDefaultAsync(m => m.MaLoaiNguyenLieu == id);

            if (loaiNguyenLieu == null)
            {
                return NotFound();
            }

            return View(loaiNguyenLieu);
        }

        // POST: Admin/IngredientCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loaiNguyenLieu = await _context.LoaiNguyenLieus.FindAsync(id);
            if (loaiNguyenLieu != null)
            {
                // Check if category has ingredients
                var hasIngredients = await _context.NguyenLieus.AnyAsync(n => n.MaLoaiNguyenLieu == id);
                if (hasIngredients)
                {
                    TempData["ErrorMessage"] = "Cannot delete category. It has associated ingredients.";
                    return RedirectToAction(nameof(Delete), new { id });
                }

                _context.LoaiNguyenLieus.Remove(loaiNguyenLieu);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool LoaiNguyenLieuExists(int id)
        {
            return _context.LoaiNguyenLieus.Any(e => e.MaLoaiNguyenLieu == id);
        }
    }
}




using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CookingWebsite.Data;
using CookingWebsite.Models;

namespace CookingWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class IngredientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IngredientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Ingredients
        public async Task<IActionResult> Index()
        {
            var nguyenLieus = await _context.NguyenLieus
                .Include(n => n.LoaiNguyenLieu)
                .OrderBy(n => n.TenNguyenLieu)
                .ToListAsync();

            return View(nguyenLieus);
        }

        // GET: Admin/Ingredients/ByRecipe/5
        public async Task<IActionResult> ByRecipe(int recipeId)
        {
            var ingredients = await _context.CongThucNguyenLieus
                .Where(cn => cn.MaCongThuc == recipeId)
                .Include(cn => cn.NguyenLieu)
                    .ThenInclude(n => n.LoaiNguyenLieu)
                .ToListAsync();

            var recipe = await _context.CongThucs.FindAsync(recipeId);
            ViewBag.RecipeId = recipeId;
            ViewBag.RecipeName = recipe?.TenCongThuc ?? "Unknown";
            ViewBag.AllIngredients = await _context.NguyenLieus
                .Include(n => n.LoaiNguyenLieu)
                .OrderBy(n => n.TenNguyenLieu)
                .ToListAsync();

            return View(ingredients);
        }

        // GET: Admin/Ingredients/Create
        public IActionResult Create()
        {
            ViewBag.LoaiNguyenLieus = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(
                _context.LoaiNguyenLieus.OrderBy(l => l.TenLoai).ToList(),
                "MaLoaiNguyenLieu",
                "TenLoai");
            return View();
        }

        // POST: Admin/Ingredients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NguyenLieu nguyenLieu)
        {
            if (ModelState.IsValid)
            {
                // Get next MaNguyenLieu
                var maxId = await _context.NguyenLieus
                    .OrderByDescending(n => n.MaNguyenLieu)
                    .Select(n => n.MaNguyenLieu)
                    .FirstOrDefaultAsync();
                nguyenLieu.MaNguyenLieu = maxId + 1;

                _context.Add(nguyenLieu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.LoaiNguyenLieus = _context.LoaiNguyenLieus.OrderBy(l => l.TenLoai).ToList();
            return View(nguyenLieu);
        }

        // GET: Admin/Ingredients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguyenLieu = await _context.NguyenLieus.FindAsync(id);
            if (nguyenLieu == null)
            {
                return NotFound();
            }

            ViewBag.LoaiNguyenLieus = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(
                _context.LoaiNguyenLieus.OrderBy(l => l.TenLoai).ToList(),
                "MaLoaiNguyenLieu",
                "TenLoai",
                nguyenLieu.MaLoaiNguyenLieu);
            return View(nguyenLieu);
        }

        // POST: Admin/Ingredients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, NguyenLieu nguyenLieu)
        {
            if (id != nguyenLieu.MaNguyenLieu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nguyenLieu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NguyenLieuExists(nguyenLieu.MaNguyenLieu))
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

            ViewBag.LoaiNguyenLieus = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(
                _context.LoaiNguyenLieus.OrderBy(l => l.TenLoai).ToList(),
                "MaLoaiNguyenLieu",
                "TenLoai",
                nguyenLieu.MaLoaiNguyenLieu);
            return View(nguyenLieu);
        }

        // GET: Admin/Ingredients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguyenLieu = await _context.NguyenLieus
                .Include(n => n.LoaiNguyenLieu)
                .FirstOrDefaultAsync(m => m.MaNguyenLieu == id);

            if (nguyenLieu == null)
            {
                return NotFound();
            }

            return View(nguyenLieu);
        }

        // POST: Admin/Ingredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nguyenLieu = await _context.NguyenLieus.FindAsync(id);
            if (nguyenLieu != null)
            {
                // Check if ingredient is used in recipes
                var isUsed = await _context.CongThucNguyenLieus.AnyAsync(cn => cn.MaNguyenLieu == id);
                if (isUsed)
                {
                    TempData["ErrorMessage"] = "Cannot delete ingredient. It is used in one or more recipes.";
                    return RedirectToAction(nameof(Delete), new { id });
                }

                _context.NguyenLieus.Remove(nguyenLieu);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: Admin/Ingredients/AddToRecipe
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToRecipe(int recipeId, int ingredientId)
        {
            var exists = await _context.CongThucNguyenLieus
                .AnyAsync(cn => cn.MaCongThuc == recipeId && cn.MaNguyenLieu == ingredientId);

            if (!exists)
            {
                var maxId = await _context.CongThucNguyenLieus
                    .OrderByDescending(cn => cn.IdCongThucNguyenLieu)
                    .Select(cn => cn.IdCongThucNguyenLieu)
                    .FirstOrDefaultAsync();

                _context.CongThucNguyenLieus.Add(new CongThucNguyenLieu
                {
                    IdCongThucNguyenLieu = maxId + 1,
                    MaCongThuc = recipeId,
                    MaNguyenLieu = ingredientId
                });
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(ByRecipe), new { recipeId });
        }

        // POST: Admin/Ingredients/RemoveFromRecipe
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveFromRecipe(int recipeId, int id)
        {
            var congThucNguyenLieu = await _context.CongThucNguyenLieus.FindAsync(id);
            if (congThucNguyenLieu != null)
            {
                _context.CongThucNguyenLieus.Remove(congThucNguyenLieu);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(ByRecipe), new { recipeId });
        }

        private bool NguyenLieuExists(int id)
        {
            return _context.NguyenLieus.Any(e => e.MaNguyenLieu == id);
        }
    }
}


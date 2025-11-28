using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CookingWebsite.Data;
using CookingWebsite.Models;

namespace CookingWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class StepsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StepsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Steps/ByRecipe/5
        public async Task<IActionResult> ByRecipe(int recipeId)
        {
            var steps = await _context.CacBuocNaus
                .Where(s => s.MaCongThuc == recipeId)
                .OrderBy(s => s.BuocThucHien)
                .ToListAsync();

            var recipe = await _context.CongThucs.FindAsync(recipeId);
            ViewBag.RecipeId = recipeId;
            ViewBag.RecipeName = recipe?.TenCongThuc ?? "Unknown";

            return View(steps);
        }

        // GET: Admin/Steps/Create
        public IActionResult Create(int recipeId)
        {
            var recipe = _context.CongThucs.Find(recipeId);
            ViewBag.RecipeId = recipeId;
            ViewBag.RecipeName = recipe?.TenCongThuc ?? "Unknown";
            return View();
        }

        // POST: Admin/Steps/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CacBuocNau step)
        {
            if (ModelState.IsValid)
            {
                // Get next MaBuoc
                var maxBuoc = await _context.CacBuocNaus
                    .OrderByDescending(b => b.MaBuoc)
                    .Select(b => b.MaBuoc)
                    .FirstOrDefaultAsync();
                step.MaBuoc = maxBuoc + 1;

                _context.Add(step);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ByRecipe), new { recipeId = step.MaCongThuc });
            }

            ViewBag.RecipeId = step.MaCongThuc;
            return View(step);
        }

        // GET: Admin/Steps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var step = await _context.CacBuocNaus.FindAsync(id);
            if (step == null)
            {
                return NotFound();
            }

            var recipe = await _context.CongThucs.FindAsync(step.MaCongThuc);
            ViewBag.RecipeName = recipe?.TenCongThuc ?? "Unknown";
            return View(step);
        }

        // POST: Admin/Steps/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CacBuocNau step)
        {
            if (id != step.MaBuoc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(step);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StepExists(step.MaBuoc))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ByRecipe), new { recipeId = step.MaCongThuc });
            }

            return View(step);
        }

        // GET: Admin/Steps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var step = await _context.CacBuocNaus
                .Include(s => s.CongThuc)
                .FirstOrDefaultAsync(m => m.MaBuoc == id);

            if (step == null)
            {
                return NotFound();
            }

            return View(step);
        }

        // POST: Admin/Steps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var step = await _context.CacBuocNaus.FindAsync(id);
            if (step != null)
            {
                var recipeId = step.MaCongThuc;
                _context.CacBuocNaus.Remove(step);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ByRecipe), new { recipeId });
            }

            return RedirectToAction(nameof(ByRecipe));
        }

        private bool StepExists(int id)
        {
            return _context.CacBuocNaus.Any(e => e.MaBuoc == id);
        }
    }
}




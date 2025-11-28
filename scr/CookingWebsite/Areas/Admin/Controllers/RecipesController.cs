using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CookingWebsite.Data;
using CookingWebsite.Models;
using X.PagedList;
using X.PagedList.Mvc.Core;
using X.PagedList.Mvc;

namespace CookingWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class RecipesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public RecipesController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Admin/Recipes
        public async Task<IActionResult> Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = page ?? 1;

            var allRecipes = await _context.CongThucs
                .OrderBy(c => c.MaCongThuc)
                .ToListAsync();

            var congThucs = new X.PagedList.PagedList<CongThuc>(allRecipes, pageNumber, pageSize);

            return View(congThucs);
        }

        // GET: Admin/Recipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var congThuc = await _context.CongThucs
                .FirstOrDefaultAsync(m => m.MaCongThuc == id);

            if (congThuc == null)
            {
                return NotFound();
            }

            return View(congThuc);
        }

        // GET: Admin/Recipes/Create
        public IActionResult Create()
        {
            ViewBag.LoaiMonAns = _context.LoaiMonAns.ToList();
            return View();
        }

        // POST: Admin/Recipes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CongThuc congThuc, IFormFile? anh, IFormFile? anhChiTiet, List<int>? selectedCategories)
        {
            if (ModelState.IsValid)
            {
                // Handle image uploads
                if (anh != null && anh.Length > 0)
                {
                    var fileName = Path.GetFileName(anh.FileName);
                    var filePath = Path.Combine(_environment.WebRootPath, "Images_NAUAN", fileName);
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await anh.CopyToAsync(stream);
                    }
                    congThuc.Anh = fileName;
                }

                if (anhChiTiet != null && anhChiTiet.Length > 0)
                {
                    var fileName = Path.GetFileName(anhChiTiet.FileName);
                    var filePath = Path.Combine(_environment.WebRootPath, "Images_NAUAN", fileName);
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await anhChiTiet.CopyToAsync(stream);
                    }
                    congThuc.AnhChiTiet = fileName;
                }

                _context.Add(congThuc);
                await _context.SaveChangesAsync();

                // Add recipe categories
                if (selectedCategories != null && selectedCategories.Any())
                {
                    foreach (var categoryId in selectedCategories)
                    {
                        _context.CongThucLoaiMonAns.Add(new CongThucLoaiMonAn
                        {
                            MaCongThuc = congThuc.MaCongThuc,
                            MaLoaiMonAn = categoryId
                        });
                    }
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }

            ViewBag.LoaiMonAns = _context.LoaiMonAns.ToList();
            return View(congThuc);
        }

        // GET: Admin/Recipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var congThuc = await _context.CongThucs.FindAsync(id);
            if (congThuc == null)
            {
                return NotFound();
            }

            ViewBag.LoaiMonAns = _context.LoaiMonAns.ToList();
            ViewBag.SelectedCategories = await _context.CongThucLoaiMonAns
                .Where(cl => cl.MaCongThuc == id)
                .Select(cl => cl.MaLoaiMonAn)
                .ToListAsync();

            return View(congThuc);
        }

        // POST: Admin/Recipes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CongThuc congThuc, IFormFile? anh, IFormFile? anhChiTiet, List<int>? selectedCategories)
        {
            if (id != congThuc.MaCongThuc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingRecipe = await _context.CongThucs.FindAsync(id);
                    if (existingRecipe == null)
                    {
                        return NotFound();
                    }

                    // Handle image uploads
                    if (anh != null && anh.Length > 0)
                    {
                        var fileName = Path.GetFileName(anh.FileName);
                        var filePath = Path.Combine(_environment.WebRootPath, "Images_NAUAN", fileName);
                        Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await anh.CopyToAsync(stream);
                        }
                        existingRecipe.Anh = fileName;
                    }

                    if (anhChiTiet != null && anhChiTiet.Length > 0)
                    {
                        var fileName = Path.GetFileName(anhChiTiet.FileName);
                        var filePath = Path.Combine(_environment.WebRootPath, "Images_NAUAN", fileName);
                        Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await anhChiTiet.CopyToAsync(stream);
                        }
                        existingRecipe.AnhChiTiet = fileName;
                    }

                    // Update other properties
                    existingRecipe.TenCongThuc = congThuc.TenCongThuc;
                    existingRecipe.MoTa = congThuc.MoTa;
                    existingRecipe.ThoiGianChuanBi = congThuc.ThoiGianChuanBi;
                    existingRecipe.TongThoiGianNau = congThuc.TongThoiGianNau;
                    existingRecipe.PhucVu = congThuc.PhucVu;
                    existingRecipe.TacGia = congThuc.TacGia;

                    // Update categories
                    var existingCategories = await _context.CongThucLoaiMonAns
                        .Where(cl => cl.MaCongThuc == id)
                        .ToListAsync();
                    _context.CongThucLoaiMonAns.RemoveRange(existingCategories);

                    if (selectedCategories != null && selectedCategories.Any())
                    {
                        foreach (var categoryId in selectedCategories)
                        {
                            _context.CongThucLoaiMonAns.Add(new CongThucLoaiMonAn
                            {
                                MaCongThuc = id,
                                MaLoaiMonAn = categoryId
                            });
                        }
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CongThucExists(congThuc.MaCongThuc))
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

            ViewBag.LoaiMonAns = _context.LoaiMonAns.ToList();
            return View(congThuc);
        }

        // GET: Admin/Recipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var congThuc = await _context.CongThucs
                .FirstOrDefaultAsync(m => m.MaCongThuc == id);

            if (congThuc == null)
            {
                return NotFound();
            }

            return View(congThuc);
        }

        // POST: Admin/Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var congThuc = await _context.CongThucs.FindAsync(id);
            if (congThuc != null)
            {
                // Check if recipe has steps or ingredients
                var hasSteps = await _context.CacBuocNaus.AnyAsync(b => b.MaCongThuc == id);
                var hasIngredients = await _context.CongThucNguyenLieus.AnyAsync(cn => cn.MaCongThuc == id);

                if (hasSteps || hasIngredients)
                {
                    TempData["ErrorMessage"] = "Không thể xóa công thức. Vui lòng xóa tất cả các bước và nguyên liệu trước.";
                    return RedirectToAction(nameof(Delete), new { id });
                }

                // Delete related CongThucLoaiMonAn records first
                var relatedCategories = await _context.CongThucLoaiMonAns
                    .Where(cl => cl.MaCongThuc == id)
                    .ToListAsync();

                if (relatedCategories.Any())
                {
                    _context.CongThucLoaiMonAns.RemoveRange(relatedCategories);
                }

                // Now delete the recipe
                _context.CongThucs.Remove(congThuc);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Xóa công thức thành công!";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool CongThucExists(int id)
        {
            return _context.CongThucs.Any(e => e.MaCongThuc == id);
        }
    }
}


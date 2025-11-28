using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CookingWebsite.Data;
using CookingWebsite.Models;
using X.PagedList;
using X.PagedList.Mvc.Core;
using X.PagedList.Mvc;

namespace CookingWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index(int? page)
        {
            int pageSize = 12;
            int pageNumber = page ?? 1;

            var allRecipes = await _context.CongThucs
                .OrderBy(c => c.MaCongThuc)
                .ToListAsync();

            var congThucs = new X.PagedList.PagedList<CongThuc>(allRecipes, pageNumber, pageSize);

            return View(congThucs);
        }

        public async Task<IActionResult> RecipeDetail(int id)
        {
            var congThuc = await _context.CongThucs
                .Include(c => c.CacBuocNaus.OrderBy(b => b.BuocThucHien))
                .Include(c => c.CongThucNguyenLieus)
                    .ThenInclude(cn => cn.NguyenLieu)
                        .ThenInclude(n => n.LoaiNguyenLieu)
                .Include(c => c.CongThucLoaiMonAns)
                    .ThenInclude(cl => cl.LoaiMonAn)
                .FirstOrDefaultAsync(c => c.MaCongThuc == id);

            if (congThuc == null)
            {
                return NotFound();
            }

            return View(congThuc);
        }

        public async Task<IActionResult> RecipesByCategory(int categoryId, int? page)
        {
            int pageSize = 9;
            int pageNumber = page ?? 1;

            var allRecipes = await _context.CongThucLoaiMonAns
                .Where(cl => cl.MaLoaiMonAn == categoryId)
                .Include(cl => cl.CongThuc)
                .Select(cl => cl.CongThuc!)
                .OrderBy(c => c.MaCongThuc)
                .ToListAsync();

            var congThucs = new X.PagedList.PagedList<CongThuc>(allRecipes, pageNumber, pageSize);

            ViewBag.CategoryId = categoryId;
            var category = await _context.LoaiMonAns.FindAsync(categoryId);
            ViewBag.CategoryName = category?.TenLoaiMonAn ?? "Unknown";

            return View(congThucs);
        }

        public async Task<IActionResult> Search(string searchText, int? page)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                return RedirectToAction(nameof(Index));
            }

            int pageSize = 12;
            int pageNumber = page ?? 1;

            var allRecipes = await _context.CongThucs
                .Where(c => c.TenCongThuc != null && c.TenCongThuc.Contains(searchText) || 
                           (c.MoTa != null && c.MoTa.Contains(searchText)))
                .OrderBy(c => c.MaCongThuc)
                .ToListAsync();

            var congThucs = new X.PagedList.PagedList<CongThuc>(allRecipes, pageNumber, pageSize);

            ViewBag.SearchText = searchText;
            return View(congThucs);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

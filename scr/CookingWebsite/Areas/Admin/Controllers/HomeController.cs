using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CookingWebsite.Data;

namespace CookingWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.TotalRecipes = _context.CongThucs.Count();
            ViewBag.TotalCategories = _context.LoaiMonAns.Count();
            ViewBag.TotalIngredients = _context.NguyenLieus.Count();
            ViewBag.TotalIngredientCategories = _context.LoaiNguyenLieus.Count();
            return View();
        }
    }
}




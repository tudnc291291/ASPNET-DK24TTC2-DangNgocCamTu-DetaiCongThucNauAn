using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CookingWebsite.Data;

namespace CookingWebsite.ViewComponents
{
    public class LoaiMonAnViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public LoaiMonAnViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loaiMonAns = await _context.LoaiMonAns
                .OrderBy(l => l.TenLoaiMonAn)
                .ToListAsync();

            return View(loaiMonAns);
        }
    }
}




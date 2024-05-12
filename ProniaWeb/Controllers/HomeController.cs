using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaWeb.DataAccesLayer;
using ProniaWeb.ViewModels.Sliders;

namespace ProniaWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProniaContext _context;

        public HomeController(ProniaContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
            var data = await _context.Sliders.Select(s => new GetSliderVM
            {
                Discount = s.Discount,
                Id = s.Id,
                ImageUrl = s.ImageUrl,
                Subtitle = s.Subtitle,
                Title = s.Title,

            }).ToListAsync();
            return View(data ?? new List<GetSliderVM>());
        }
        public async Task<IActionResult> Contact()
        {
            return View();
        }
    }
}

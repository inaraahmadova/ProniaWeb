using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaWeb.ViewModels.Products;

namespace ProniaWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products
               .Select(p => new GetProductAdminVM
               {
                   CostPrice = p.CostPrice,
                   Discount = p.Discount,
                   Id = p.Id,
                   Name = p.Name,
                   ImageUrl = p.ImageUrl,
                   Raiting = p.Raiting,
                   SellPrice = p.SellPrice,
                   Stockcount = p.Stockcount
               })
               .ToListAsync());
        }


        private IActionResult View(object value)
        {
            throw new NotImplementedException();
        }
    }
}

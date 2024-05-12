﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaWeb.DataAccesLayer;
using ProniaWeb.Models;
using ProniaWeb.ViewModels.Sliders;

namespace ProniaWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController(ProniaContext _context) : Controller
    {
        public async Task<IActionResult> Index()
        {
           var data= await _context.Sliders.Select(s=>new GetSliderVM
                { 
                Discount = s.Discount,
                Id = s.Id,
                ImageUrl = s.ImageUrl,
                Subtitle = s.Subtitle,
                Title = s.Title,

                }).ToListAsync();
            return View(data ?? new List<GetSliderVM>());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateSliderVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            Slider slider=new Slider
            {
                Discount = vm.Discount,
                CreatedTime=DateTime.Now,
                ImageUrl=vm.ImageUrl,
                IsDeleted=false,
                Subtitle=vm.Subtitle,
                Title=vm.Title,
            };
            _context.Sliders.Add(slider);   
            _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id, Slider slider)
        {
            if (id == null || id < 1) return BadRequest();
            Slider extisted = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
            if (extisted is null) return NotFound();
            extisted.Title = slider.Title;
            extisted.Subtitle = slider.Subtitle;
            extisted.ImageUrl = slider.ImageUrl;
            extisted.Discount = slider.Discount;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id < 1) return BadRequest();

            var item = await _context.Sliders.FindAsync(id);
            if (item == null) return NotFound();
            _context.Remove(item);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}

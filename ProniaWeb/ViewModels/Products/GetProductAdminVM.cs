﻿using ProniaWeb.Models;

namespace ProniaWeb.ViewModels.Products
{
    public class GetProductAdminVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellPrice { get; set; }
        public int Discount { get; set; }
        public int Stockcount { get; set; }
        public string ImageUrl { get; set; }
        public float Raiting { get; set; }
      
    }
}

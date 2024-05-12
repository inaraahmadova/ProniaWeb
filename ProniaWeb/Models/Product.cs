﻿namespace ProniaWeb.Models
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellPrice { get; set; }
        public int Discount { get; set; }
        public int Stockcount { get; set; }
        public string ImageUrl { get; set; }
        public float Raiting { get; set; }
        public ICollection<ProductImage>? Images { get; set; }
        public ICollection<Category>? Categories { get; set; }
        public ICollection<ProductCategory>? ProductCategory { get; set; }



    }
}

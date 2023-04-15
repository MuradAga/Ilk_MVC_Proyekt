﻿using AutoMapper;
using Ilk_MVC_Proyekt.Entites;

namespace Ilk_MVC_Proyekt.Models
{
    public class ProductAddDTO // Data Transfer Object
    {
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
        public double ProductPrice { get; set; }
        public int CategoryId { get; set; }
    }
}

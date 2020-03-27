﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvProj.Models
{
    class ProductModel
    {
        public int Price { get; set; }
        public string Name { get; set; }

        public ProductModel(int price, string name)
        {
            Price = price;
            Name = name;
        }
    }
}

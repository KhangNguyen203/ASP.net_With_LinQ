﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class CartModel
    {
        NorWidDataContext da = new NorWidDataContext();
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal? Total { get { return UnitPrice * Quantity; } }

        public CartModel(int id)
        {
            Product p = da.Products.FirstOrDefault(s => s.ProductID == id);
            ProductID = p.ProductID;
            ProductName = p.ProductName;
            UnitPrice = p.UnitPrice;
            Quantity = 1;
        }
    }
}
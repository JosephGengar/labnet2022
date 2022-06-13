using Linq.Entities;
using Linq.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.Logic
{
    public class ProductsLogic : BaseLogic
    {
        public List<Products> GetProductsOfStock()
        {
            var query2 = db.Products.Where(p => p.UnitsInStock == 0).ToList();
            return query2;
        }
        public List<Products> GetProductsWStockM3()
        {
            var query3 = (from p in db.Products
                          where p.UnitsInStock != 0 && p.UnitPrice > 3
                          select p).ToList();
            return query3;
        }
        public List<Products> GetProduct789()
        {
            List<Products> ProductsList = new List<Products>();
            var query4 = db.Products.FirstOrDefault(p => p.CategoryID == 789);
            ProductsList.Add(query4);
            return ProductsList;
        }
        public List<Products> GetProductsOrder()
        {
            var query9 = (from p in db.Products
                          orderby p.ProductName
                          select p).ToList();
            return query9;
        }
        public List<Products> GetProductsOrdMM()
        {
            var query10 = db.Products.OrderByDescending(p => p.UnitsInStock).Select(p => p).ToList();
            return query10;
        }
        public List<Product_CatModel> GetProduct_Category()
        {
            var query11 = (from p in db.Products
                           join c in db.Categories
                           on p.CategoryID equals c.CategoryID
                           select new Product_CatModel
                           {
                               ProductName = p.ProductName,
                               CategoryName = c.CategoryName
                           }).ToList();
            return query11;
        }
        public List<Products> GetProdFirstElement()
        {
            var query12 = db.Products.Take(1).ToList();
            return query12;
        }
    }
}

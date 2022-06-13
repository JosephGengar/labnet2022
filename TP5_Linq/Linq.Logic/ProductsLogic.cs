using Linq.Entities;
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
    }
}

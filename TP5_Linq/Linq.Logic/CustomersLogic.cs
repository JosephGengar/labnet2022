using Linq.Entities;
using Linq.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.Logic
{
    public class CustomersLogic : BaseLogic
    {
        public List<Customers> GetCustomers()
        {
            var query1 = (from c in db.Customers
                         select c).ToList();
            return query1;
        }
        public List<Customers> GetCustomersWA()
        {
            var query4 = db.Customers.Where(c => c.Region == "WA").ToList();
            return query4;
        }
        public List<CustomersMMModel> GetCustomersMM()
        {
            var query6 = (from c in db.Customers
                         select new CustomersMMModel
                         {
                             CustomerID = c.CustomerID,
                             CompanyNameUpper = c.CompanyName.ToUpper(),
                             CompanyNameLower = c.CompanyName.ToLower()
                         }).ToList();
            return query6;
        }
        public List<Customers_OrdersModel> GetCustomers_Orders()
        {
            DateTime Date19970101 = new DateTime(1997, 1, 1);
            var query7 = (from c in db.Customers
                          join o in db.Orders
                          on c.CustomerID equals o.CustomerID
                          where c.Region == "WA" && o.OrderDate > Date19970101
                          select new Customers_OrdersModel
                          {
                              CompanyName = c.CompanyName,
                              OrderID = o.OrderID
                          }).ToList();
            return query7;
        }
    }
}

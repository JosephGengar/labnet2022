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
                              OrderID = o.OrderID,
                              Region = c.Region,
                              DateTime1997 = o.OrderDate
                          }).ToList();
            return query7;
        }
        public List<Customers> GetCustomers3R()
        {
            var query8 = db.Customers.Where(c => c.Region == "WA").Take(3).ToList();
            return query8;
        }
        public List<Customer_OrdersCantModel> GetCust_Order()
        {
            var query13 = (from c in db.Customers
                           join o in db.Orders
                           on c.CustomerID equals o.CustomerID
                           group o by c into or
                           let NumOrd = or.Count()
                           select new Customer_OrdersCantModel
                           {
                               CompanyName = or.Key.CompanyName,
                               Quantity = NumOrd
                           }).ToList();
            return query13;
            //en clase group c by new { companyName, OrderID } into or ......
        }
    }
}

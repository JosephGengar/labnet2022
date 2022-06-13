using Linq.Entities;
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
            var query = (from c in db.Customers
                         select c).ToList();
            return query;
        }
    }
}

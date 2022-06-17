using Entity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Logic
{
    public class BaseLogic
    {
        protected readonly NorthWindContext db;
        public BaseLogic()
        {
            this.db = new NorthWindContext();
        }
    }
}

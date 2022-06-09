using Entity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.logic
{
    public class BaseLogic
    {
        protected readonly NorthWindContext Context;
        public BaseLogic()
        {
            this.Context = new NorthWindContext();
        }
    }
}

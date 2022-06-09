using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.logic
{
    interface ILogic<T>
    {
        List<T> GetAll();
    }
}


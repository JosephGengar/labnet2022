using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Logic
{
    interface ILogic<T>
    {
        List<T> GetAll();
    }
}

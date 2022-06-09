using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.logic
{
    public class TerritoriesLogic : BaseLogic, ILogic<Territories>
    {
        public List<Territories> GetAll()
        {
            return Context.Territories.ToList(); ;
        }
    }
}

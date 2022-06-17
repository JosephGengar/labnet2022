using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Logic
{
    public class TerritoriesLogic : BaseLogic, ILogic<Territories>
    {
        public List<Territories> GetAll()
        {
            return db.Territories.ToList();
        }
    }
}

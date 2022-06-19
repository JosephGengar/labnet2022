using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Logic
{
    public class ShippersLogic : BaseLogic, ILogic<Shippers>
    {
        public List<Shippers> GetAll()
        {
            return db.Shippers.Where(d => d.Phone != null).ToList();
        }
        public Shippers GetOne(int id)
        {
            var ShipperOne = db.Shippers.Find(id);
            return ShipperOne;
        }
        public void Add(Shippers oShippers)
        {
            db.Shippers.Add(oShippers);
            db.SaveChanges();
        }
        public void Edit(Shippers oShippers)
        {          
                var ShipperE = db.Shippers.Find(oShippers.ShipperID);
                ShipperE.CompanyName = oShippers.CompanyName;
                ShipperE.Phone = oShippers.Phone;
                db.Entry(ShipperE).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();         
          
        }
        public void Delete(int id)
        {
            var ShipperD = db.Shippers.Find(id);
            db.Shippers.Remove(ShipperD);
            db.SaveChanges();
        }
        public void LogicDelete(int id)
        {
            var ShipperDL = db.Shippers.Find(id);
            ShipperDL.Phone = null;
            db.Entry(ShipperDL).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}

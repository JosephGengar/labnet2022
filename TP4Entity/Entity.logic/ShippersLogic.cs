using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.logic
{
    public class ShippersLogic : BaseLogic, ILogic<Shippers>
    {
        public List<Shippers> GetAll()
        {
            return Context.Shippers.Where(d => d.Phone != null).ToList();
        }
        public Shippers GetOne(int id)
        {
            var ShipperOne = Context.Shippers.Find(id);
            return ShipperOne;
        }
        public void Add(Shippers oShippers)
        {
            Context.Shippers.Add(oShippers);
            Context.SaveChanges();
        }
        public void Edit(Shippers oShippers)
        {
            var ShipperE = Context.Shippers.Find(oShippers.ShipperID);
            ShipperE.CompanyName = oShippers.CompanyName;
            ShipperE.Phone = oShippers.Phone;
            Context.Entry(ShipperE).State = System.Data.Entity.EntityState.Modified;
            Context.SaveChanges();
        }
        public void Delete(int id)
        {
            var ShipperD = Context.Shippers.Find(id);
            Context.Shippers.Remove(ShipperD);
            Context.SaveChanges();
        }
        public void DeleteLogic(int id)
        {
            var ShipperDL = Context.Shippers.Find(id);
            ShipperDL.Phone = null;
            Context.Entry(ShipperDL).State = System.Data.Entity.EntityState.Modified;
            Context.SaveChanges();
        }
    }
}

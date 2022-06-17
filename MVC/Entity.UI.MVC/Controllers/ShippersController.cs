using Entity.Entities;
using Entity.Logic;
using Entity.UI.MVC.Models.BackModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Entity.UI.MVC.Controllers
{
    public class ShippersController : Controller
    {  
        ShippersLogic oShippersL = new ShippersLogic();

        [HttpGet]
        public ActionResult Index()
        {
            List<Shippers> ShippersList = oShippersL.GetAll();
            List<ShippersBackView> ShippersBackViewList = ShippersList.Select(s => new ShippersBackView
            {
                ShipperID = s.ShipperID,
                CompanyName = s.CompanyName,
                PhoneNumber = s.Phone
            }).ToList();
            ViewBag.Script = "List Loaded 2";
            ViewBag.Alert = "List Loaded";
            return View(ShippersBackViewList);
        }





        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                oShippersL.Delete((int) id);
                return Content("1");
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    oShippersL.LogicDelete((int)id);                  
                    return Content("2");
                }
                else
                {                                    
                    return Content("3");
                }
                
            }
        }
       
    }
}
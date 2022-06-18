﻿using Entity.Entities;
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
            ViewBag.Alert = "Data uploaded successfully";
            return View(ShippersBackViewList);
        }
        public ActionResult Add()
        {          
            return View();
        }
        [HttpPost]
        public ActionResult Add(ShipperAddView model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Shippers oShippers = new Shippers();         
            oShippers.CompanyName = model.CompanyName;
            oShippers.Phone = model.PhoneNumber;
            oShippersL.Add(oShippers);
            return Redirect(Url.Content("~/Shippers/"));
        }

        public ActionResult Edit(int id)
        {
            Shippers oShipeers = oShippersL.GetOne(id);
            ShippersBackView oShipperBV = new ShippersBackView
            {
                ShipperID = oShipeers.ShipperID,
                CompanyName = oShipeers.CompanyName,
                PhoneNumber = oShipeers.Phone
            };
            return View("Edit", oShipperBV);
        }
        [HttpPost]
        public ActionResult Edit(ShippersBackView model)
        {
            if (!ModelState.IsValid)
            {              
                    return View(model);                                            
            }
            
            Shippers oShippers = new Shippers
            {
               ShipperID = model.ShipperID,
               CompanyName = model.CompanyName,
               Phone = model.PhoneNumber
            };
            oShippersL.Edit(oShippers);
            return Redirect(Url.Content("~/Shippers/"));
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
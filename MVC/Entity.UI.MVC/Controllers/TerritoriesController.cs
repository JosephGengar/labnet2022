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
    public class TerritoriesController : Controller
    {
        TerritoriesLogic oTerrL = new TerritoriesLogic();
        // GET: Territories
        public ActionResult Index()
        {
            List<Territories> TerritoriesList = oTerrL.GetAll();
            List<TerritoriesBackView> TerritoriesBackViewList = TerritoriesList.Select(s => new TerritoriesBackView
            {
                TerritoriesID = s.TerritoryID,
                TerritoriesDescripcion = s.TerritoryDescription,
                RegionID = s.RegionID
            }).ToList();
            ViewBag.Alert = "Data uploaded successfully";
            return View(TerritoriesBackViewList);
        }
    }
}
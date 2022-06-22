using Entity.Entities;
using Entity.Logic;
using Entity.MVC.API.Models;
using Entity.MVC.API.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Entity.MVC.API.Controllers
{
    public class ShippersController : ApiController
    {
        ShippersLogic oShippersL = new ShippersLogic();
        //Get https://localhost:xxxxx/api/Shippers
        public IHttpActionResult GetShippers()
        {
            ResponseBack oResponse = new ResponseBack();
            try
            {
                List<Shippers> ShippersList = oShippersL.GetAll();
                List<ShippersView> ShippersBackViewList = ShippersList.Select(s => new ShippersView
                {
                    ShipperID = s.ShipperID,
                    CompanyName = s.CompanyName,
                    PhoneNumber = s.Phone
                }).ToList();
                oResponse.data = ShippersBackViewList;
                oResponse.exito = 1;
            }
            catch (Exception ex)
            {
                oResponse.exito = 0;
                oResponse.message = ex.Message;
            }
            return Ok(oResponse);
        }
        //Delete https://localhost:xxxxx/api/Shippers/id
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            ResponseBack oResponse = new ResponseBack();
            try
            {
                oShippersL.Delete(id);
                oResponse.exito = 1;
            }
            catch (Exception ex)
            {
                oResponse.exito = 0;
                oResponse.message = ex.Message;
            }
            return Ok(oResponse);
        }
    }
}

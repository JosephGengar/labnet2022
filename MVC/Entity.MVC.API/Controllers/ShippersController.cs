using Entity.Entities;
using Entity.Logic;
using Entity.MVC.API.Models;
using Entity.MVC.API.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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
                oResponse.message = "Shipper Deleted";
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    oShippersL.LogicDelete(id);
                    oResponse.exito = 1;
                    oResponse.message = "Error with delete operation, however the system looked for a way to solve it";
                }
                else
                {
                    oResponse.exito = 0;
                    oResponse.message = ex.Message;
                }              
            }
            return Ok(oResponse);
        }

        //{                               {
        //"CompanyName" : "string",       "ShipperID" : int,
        //"PhoneNumber" : "string"        "CompanyName" : "string", 
        //}                               "PhoneNumber" : "string   }
        [HttpPost]
        public IHttpActionResult AddEdit(ShippersView model)
        {
            ResponseBack oResponse = new ResponseBack();
            try
            {
                if (model.ShipperID != 0)
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }
                    else
                    {
                        Shippers oShippers = new Shippers
                        {
                            ShipperID = model.ShipperID,
                            CompanyName = model.CompanyName,
                            Phone = model.PhoneNumber
                        };
                        oShippersL.Edit(oShippers);
                        oResponse.exito = 1;
                        oResponse.message = "Shipper Edited";
                    }
                }
                else
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }
                    else
                    {
                        Shippers oShippers = new Shippers();
                        oShippers.CompanyName = model.CompanyName;
                        oShippers.Phone = model.PhoneNumber;
                        oShippersL.Add(oShippers);
                        oResponse.exito = 1;
                        oResponse.message = "Saved Shipper";
                    }
                }
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

using Entity.Data;
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
using System.Web.Http.Cors;

namespace Entity.MVC.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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
                oResponse.sucess = 1;
            }
            catch (Exception ex)
            {
                oResponse.sucess = 0;
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
                oResponse.sucess = 1;
                oResponse.message = "Shipper Deleted";
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    oShippersL.LogicDelete(id);
                    oResponse.sucess = 1;
                    oResponse.message = "Error with delete operation, however the system looked for a way to solve it";
                }
                else
                {
                    oResponse.sucess = 0;
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
                        oResponse.sucess = 1;
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
                        oResponse.sucess = 1;
                        oResponse.message = "Saved Shipper";
                    }
                }
            }
            catch (Exception ex)
            {
                oResponse.sucess = 0;
                oResponse.message = ex.Message;
            }
            return Ok(oResponse);
        }
        //metodo especial para validar en angular un Company Name diferente
        [HttpPatch]
        public IHttpActionResult GetName(ShippersView NameView)
        {
            ResponseBack oResponse = new ResponseBack();
            try
            {
                using (NorthWindContext db = new NorthWindContext())
                {
                    if (db.Shippers.Where(s => s.CompanyName == NameView.CompanyName).Count() > 0)
                    {
                        oResponse.sucess = 1;
                        oResponse.message = "Existente";
                    }
                    else
                    {
                        oResponse.sucess = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                oResponse.sucess = 0;
                throw ex;
            }
            return Ok(oResponse);
        }
    }
}

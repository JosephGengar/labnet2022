using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Entity.MVC.API.Models.ViewModels
{
    public class ShippersView
    {
        public int ShipperID { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
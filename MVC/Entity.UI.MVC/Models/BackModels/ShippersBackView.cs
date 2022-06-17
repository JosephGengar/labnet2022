﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Entity.UI.MVC.Models.BackModels
{
    public class ShippersBackView
    {
        [Required]
        public int ShipperID { get; set; }

        [Required]
        [StringLength(40)]
        public string CompanyName { get; set; }
        [Required]
        [StringLength(24)]
        public string PhoneNumber { get; set; }
    }
}
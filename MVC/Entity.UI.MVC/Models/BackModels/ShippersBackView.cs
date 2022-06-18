using Entity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Entity.UI.MVC.Models.BackModels
{
    public class ShippersBackView
    {    
        public int ShipperID { get; set; }

        [Required]
        [StringLength(45)]
        [Display(Name = "Company Name")]      
        public string CompanyName { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        //[RegularExpression("^[a-zA-Z]+$", ErrorMessage = "only accept letters")]
        //[RegularExpression("(^[0-9]+$)", ErrorMessage = "Only Accept Numbers")]
    }
   
}
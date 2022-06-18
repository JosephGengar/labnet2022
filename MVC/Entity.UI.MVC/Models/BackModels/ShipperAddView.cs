using Entity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Entity.UI.MVC.Models.BackModels
{
    public class ShipperAddView
    {
        [Required]
        [StringLength(45)]
        [Display(Name = "Company Name")]
        [CompanyNameExist]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
    public class CompanyNameExistAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            using (NorthWindContext db = new NorthWindContext())
            {
                string Company = (string)value;
                if (db.Shippers.Where(s => s.CompanyName == Company).Count() > 0)
                {
                    return new ValidationResult("Company Name Exists");
                }
            }
            return ValidationResult.Success;
        }
    }
}
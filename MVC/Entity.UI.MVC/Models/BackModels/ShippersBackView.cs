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

        //[CompanyNameExist]
        [Required]
        [StringLength(45)]
        [Display(Name = "Company Name")]       
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
        //por que no utilizo mi nuevo validation atribute? se puede quitar el comentario en mi data notacion para ver como funciona... 
        //es una validacion que esta excelente para el Add, sin embargo en el edit, entra en conflicto claramente, dado que siempre
        //va a existir, si bien no pincha la app es una validacion algo irrelevante para ese metodo, si hubiera hecho 2 modelos
        //por separado estaria ok, pero la consigna me limitaba a hacer un solo modelo para un solo view (agregar y editar).
    }
}
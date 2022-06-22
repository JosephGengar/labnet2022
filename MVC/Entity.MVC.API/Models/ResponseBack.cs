using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity.MVC.API.Models
{
    public class ResponseBack
    {
        public int exito { get; set; }
        public object data { get; set; }
        public string message { get; set; }
    }
}
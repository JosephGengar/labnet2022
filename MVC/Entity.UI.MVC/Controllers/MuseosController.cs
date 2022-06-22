using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Entity.UI.MVC.Controllers
{
    public class MuseosController : Controller
    {
        // GET: Museos
        public async Task<ActionResult> Index()
        {
            var httpClientApi = new HttpClient();
            var jsonEntry = await httpClientApi.GetStringAsync("https://www.cultura.gob.ar/api/v2.0/museos/");
            var museos = JsonConvert.DeserializeObject(jsonEntry);
            return View(museos);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTIGA.Models;

namespace WebTIGA.Controllers
{
    public class WebRyCController : Controller
    {
        MultiserviciosEntities db = new MultiserviciosEntities();
        ContenedorModelos modelDB = new ContenedorModelos();
        public ActionResult Index()
        {
            return View();
        }
    }
}
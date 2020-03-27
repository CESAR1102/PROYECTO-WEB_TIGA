using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTIGA.Models;

namespace WebTIGA.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult Index()
        {
            return View();
        }

        // GET: Usuarios
        SesionData session = new SesionData();
        private MultiserviciosEntities db = new MultiserviciosEntities();
        ContenedorModelos model = new ContenedorModelos();

    
     



    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTIGA.Models;

namespace WebTIGA.Controllers
{
    public class HomeController : Controller
    {
        MultiserviciosEntities db = new MultiserviciosEntities();
        ContenedorModelos modelDB = new ContenedorModelos();
        PROYECTOSIAV2Entities1 db2 = new PROYECTOSIAV2Entities1();
        RecoveryViewModel model = new RecoveryViewModel();
        public ActionResult Index()
        {

            var usuario = Convert.ToInt32(Session["IdUser"]);
            var nombre = Convert.ToString(Session["usuario"]);
          
            ViewBag.nombre = nombre;
            modelDB.SP_MODULOS_USUARIOS_Result = db2.SP_MODULOS_USUARIOS(usuario);
            

            
            return View(modelDB);
        }

    }
}
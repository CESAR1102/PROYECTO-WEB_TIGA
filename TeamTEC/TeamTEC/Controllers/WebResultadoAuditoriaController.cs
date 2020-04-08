using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTIGA.Controllers
{
    public class WebResultadoAuditoriaController : Controller
    {
        // GET: WebResultadoAuditoria
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Dashboard_WRA()
        {
            return View();
        }
        public ActionResult Detalle_Resultados_Auditoria()
        {
            return View();
        }
        public ActionResult Detalle_Seguimiento_Observaciones()
        {
            return View();
        }
        public ActionResult Detalle_Controles_Evaluados()
        {
            return View();
        }
    }
}
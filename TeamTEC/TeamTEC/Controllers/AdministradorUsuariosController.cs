using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebTIGA.Models;


namespace WebTIGA.Controllers
{
    public class AdministradorUsuariosController : Controller
    {
        SesionData session = new SesionData();
        PROYECTOSIAV2Entities1 db = new PROYECTOSIAV2Entities1();
        ContenedorModelos modelDB = new ContenedorModelos();
        RecoveryViewModel model = new RecoveryViewModel();
    
        // GET: AdministradorUsuarios
        public ActionResult Administrador_U(string mensaje_editar,string mensaje_eliminar,string mensaje_crear)
        {
            ViewBag.mensaje = mensaje_editar;
            ViewBag.delete = mensaje_eliminar;
            ViewBag.create = mensaje_crear;

            var nombre = Convert.ToString(Session["usuario"]);
            ViewBag.nombre = nombre;
            var PersonaVista = from c in db.Persona select new { c.IdPersona, Nombre_Ape= c.Nombres + " " + c.Apellidos };

            ViewBag.IdUsuario = new SelectList(PersonaVista.ToList(), "IdPersona", "Nombre_Ape");

            var usuarioModuloRol = db.UsuarioModuloRol.Include(u => u.ModuloRol).Include(u => u.Usuario).OrderBy(u=>u.Usuario.Persona.Nombres);
            return View(usuarioModuloRol.ToList());
        }
        [HttpPost]
        public ActionResult Administrador_U(UsuarioModuloRol usuarioModuloRol)
        {

            ViewBag.Message = "Ya fue asignado el registro";
            var query = from u in db.UsuarioModuloRol
                        where u.IdUsuario == usuarioModuloRol.IdUsuario 
                        select u;

            var PersonaVista = from c in db.Persona select new { c.IdPersona, Nombre_Ape = c.Nombres + " " + c.Apellidos };

            ViewBag.IdUsuario = new SelectList(PersonaVista.ToList(), "IdPersona", "Nombre_Ape", usuarioModuloRol.IdUsuario);
          
            if (query.Count() > 0)
            {
                var datos = query.ToList();
                return View(datos);
            }
            else
            {
                var datos = query.ToList();
                return View(datos);    
            }
        }


        public ActionResult Create(string mensaje_crear_falla)
        {
            ViewBag.Message = mensaje_crear_falla;
            Session["IdModulo"] = 1;
            int IdModulo = Convert.ToInt32(Session["IdModulo"]);
            ViewBag.IdModulo = IdModulo;

            modelDB.Usuario = db.Usuario.ToList();
            modelDB.Modulo1 = db.Modulo.ToList();
            modelDB.SP_WT_ROLES_MODULO_Result = db.SP_WT_ROLES_MODULO(IdModulo);

            var PersonaVista = from c in db.Persona select new { c.IdPersona, Nombre_Ape = c.Nombres + " " + c.Apellidos };

            ViewBag.IdUsuario = new SelectList(PersonaVista.ToList(), "IdPersona", "Nombre_Ape");
            ViewBag.ModuloRol = db.SP_WT_ROLES_MODULO(IdModulo);
            ViewBag.IdModulo = new SelectList(db.Modulo, "IdModulo", "Nombre");
            ViewBag.IdRol = new SelectList(db.SP_WT_ROLES_MODULO(IdModulo), "IdRol", "Tiporol");
         
            return View(modelDB);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUsuario,IdModulo,IdRol,ID")] UsuarioModuloRol usuarioModuloRol)
        {
            if (usuarioModuloRol.IdRol == 0)
            {
                var Persona = from c in db.Persona select new {  c.IdPersona,Nombre_Ape = c.Nombres + " " + c.Apellidos };

                ViewBag.IdUsuario = new SelectList(Persona.ToList(), "IdPersona", "Nombre_Ape");
                modelDB.Usuario = db.Usuario.ToList();
                modelDB.Modulo1 = db.Modulo.ToList();
                modelDB.SP_WT_ROLES_MODULO_Result = db.SP_WT_ROLES_MODULO(usuarioModuloRol.IdModulo);
                ViewBag.IdModulo = new SelectList(db.Modulo, "IdModulo", "Nombre", usuarioModuloRol.IdUsuario);
                ViewBag.IdRol = new SelectList(db.SP_WT_ROLES_MODULO(usuarioModuloRol.IdModulo), "IdRol", "Tiporol", usuarioModuloRol.IdUsuario);
                return View(modelDB);
            }
            if (ModelState.IsValid)
            {
                var query = from u in db.UsuarioModuloRol
                            where u.IdUsuario == usuarioModuloRol.IdUsuario && u.IdModulo == usuarioModuloRol.IdModulo && u.IdRol == usuarioModuloRol.IdRol
                            select u;

                if (query.Count() > 0)
                {
                    //ViewBag.Message = "Ya fue asignado el registro";
                    //return RedirectToAction("Administrador_U");

                    return RedirectToAction("Create", "AdministradorUsuarios", new {  @mensaje_crear_falla = " Ya fue creado el registro con este rol ." });
                }
                else
                {
                    usuarioModuloRol.Estado = 1;
                    db.UsuarioModuloRol.Add(usuarioModuloRol);
                    db.SaveChanges();

                    return RedirectToAction("Administrador_U", "AdministradorUsuarios", new { @mensaje_crear = " El Registro se creo con exito ." });
                    //return RedirectToAction("Administrador_U");
                }

            }
            var PersonaVista = from c in db.Persona select new { c.IdPersona, Nombre_Ape = c.Nombres + " " + c.Apellidos };
            ViewBag.IdUsuario = new SelectList(PersonaVista.ToList(), "IdPersona", "Nombre_Ape", usuarioModuloRol.IdUsuario);
            //ViewBag.IdUsuario = new SelectList(db.Persona, "IdPersona", "Nombres", usuarioModuloRol.IdUsuario);
            ViewBag.IdModulo = new SelectList(db.ModuloRol, "IdModulo", "IdModulo", usuarioModuloRol.IdModulo);

            return View(usuarioModuloRol);
        }


        // GET: AdministradorUsuarios/Edit/5
        public ActionResult Edit(int? id,int? idusuario, int? idmodulo,int? idrol,int? Estadoid,string mensaje_editar_falla)
        {
            ViewBag.Message = mensaje_editar_falla;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioModuloRol usuarioModuloRol = db.UsuarioModuloRol.Find(id);
            //ModuloRol moduloRol = db.ModuloRol.Find(idmodulo,idrol);
            ViewBag.userN = usuarioModuloRol.Usuario.Persona.Nombres + " " + usuarioModuloRol.Usuario.Persona.Apellidos;

            var usuarioN = from a in db.Usuario
                           where a.IdUsuario==idusuario
                           select a;

            var tiporol = from t in db.ModuloRol
                            where t.IdModulo == idmodulo
                            select t;
            var nombreModulo = from n in db.UsuarioModuloRol
                               where n.ID == id 
                               select n;
            var estadoid = from e in db.ModuloRol
                           where e.IdModulo == idmodulo && e.Estado==Estadoid
                           select e;
            modelDB.ModuloRol = tiporol.ToList();
            modelDB.UsuarioModuloRol = nombreModulo.ToList();
            modelDB.Usuario = usuarioN.ToList();
            modelDB.ModuloRol = estadoid.ToList();
            ViewBag.IdRol = new SelectList(db.SP_WT_ROLES_MODULO(idmodulo), "IdRol", "Tiporol");
         

            return View(modelDB);
        }

        // POST: AdministradorUsuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUsuario,IdModulo,IdRol,ID")] UsuarioModuloRol usuarioModuloRol)
        {
            

            if (ModelState.IsValid)
            {

                var query = from u in db.UsuarioModuloRol
                            where u.IdUsuario == usuarioModuloRol.IdUsuario && u.IdModulo == usuarioModuloRol.IdModulo && u.IdRol == usuarioModuloRol.IdRol
                            select u;

                if (query.Count() > 0)
                {
                    
                    
                    return RedirectToAction("Edit","AdministradorUsuarios", new { @id= usuarioModuloRol.ID, @idusuario=usuarioModuloRol.IdUsuario, @idmodulo=usuarioModuloRol.IdModulo, @idrol=usuarioModuloRol.IdRol ,@mensaje_editar_falla=" Ya fue creado el registro con este rol ."});
                    //return RedirectToAction("Administrador_U");
                }
                else
                {
                    usuarioModuloRol.Estado = 1;
                    db.Entry(usuarioModuloRol).State = EntityState.Modified;
                    db.SaveChanges();
                    session.setSession("mensaje", "El Registro se cambio con exito .");
                    return RedirectToAction("Administrador_U", "AdministradorUsuarios", new { @mensaje_editar = "El Registro se edito con exito " });
                }



            }

          

            ViewBag.IdRol = new SelectList(db.SP_WT_ROLES_MODULO(usuarioModuloRol.IdModulo), "IdRol", "Tiporol", usuarioModuloRol.IdUsuario);

            return View(usuarioModuloRol);
        }

        // GET: AdministradorUsuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioModuloRol usuarioModuloRol = db.UsuarioModuloRol.Find(id);
            ViewBag.userN = usuarioModuloRol.Usuario.Persona.Nombres + " " + usuarioModuloRol.Usuario.Persona.Apellidos;
            ViewBag.modulo = usuarioModuloRol.ModuloRol.Modulo.Nombre;
            ViewBag.rol = usuarioModuloRol.ModuloRol.Rol.Tiporol;
            ViewBag.estado = usuarioModuloRol.Estado;
            if (usuarioModuloRol == null)
            {
                return HttpNotFound();
            }
            return View(usuarioModuloRol);
        }

        // POST: AdministradorUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsuarioModuloRol usuarioModuloRol = db.UsuarioModuloRol.Find(id);

            ViewBag.userN = usuarioModuloRol.Usuario.Persona.Nombres + " " + usuarioModuloRol.Usuario.Persona.Apellidos;
            ViewBag.modulo = usuarioModuloRol.ModuloRol.Modulo.Nombre;
            ViewBag.rol = usuarioModuloRol.ModuloRol.Rol.Tiporol;
            ViewBag.estado = usuarioModuloRol.Estado;
            db.UsuarioModuloRol.Remove(usuarioModuloRol);
            db.SaveChanges();
            //return RedirectToAction("Administrador_U");
            return RedirectToAction("Administrador_U", "AdministradorUsuarios", new { @mensaje_eliminar = "El Registro se eliminó con exito ." });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Administrador_Modulos()
        {
            ContenedorModelos mymodel = new ContenedorModelos();
            //    ViewBag.IdUsuario = new SelectList(db.Modulo, "IdModulo", "Nombre");

            //    var ModuloRol = db.ModuloRol.Include(u => u.Modulo).Include(u => u.Rol);


            //mymodel.VIEW_WT_ADMIN_MODULO_ROL = db.VIEW_WT_ADMIN_MODULO_ROL;
            
            return View(mymodel);
        }
        //[HttpPost]
        //public ActionResult Administrador_Modulos(ModuloRol modulorol)
        //{

            
        //    ViewBag.IdUsuario = new SelectList(db.Modulo, "IdModulo", "Nombre");
          

        //    return View();
        //}




    }
}

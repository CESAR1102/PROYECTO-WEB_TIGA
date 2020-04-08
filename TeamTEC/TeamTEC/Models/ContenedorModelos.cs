using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebTIGA.Models
{
    public class ContenedorModelos
    {
        public IEnumerable<WebTIGA.Models.SP_GRAF_TABLA_HORAS2_Result> SP_GRAF_TABLA_HORAS2 { get; set; }
        public IEnumerable<WebTIGA.Models.SP_TBL_DETALLE_GENERAL_TEC_Result> SP_TBL_DETALLE_GENERAL_TEC { get; set; }
        public IEnumerable<WebTIGA.Models.SP_TT_DETALLE_PROYECTO_ACTIVIDAD_Result> SP_TT_DETALLE_PROYECTO_ACTIVIDAD { get; set; }
        public IEnumerable<WebTIGA.Models.SP_TT_DETALLE_ETAPAS_FASES_ACTIVIDADES_Result> SP_TT_DETALLE_ETAPAS_FASES_ACTIVIDADES { get; set; }
        public IEnumerable<WebTIGA.Models.SP_TT_EQUIPO_ETAPAS_Result> SP_TT_EQUIPO_ETAPAS { get; set; }
        public IEnumerable<WebTIGA.Models.SP_TT_DETALLE_FILTRAR_PROYECTO_Result> SP_TT_DETALLE_FILTRAR_PROYECTO { get; set; }
        public IEnumerable<WebTIGA.Models.SP_TT_DIAS_CONTROL_Result> SP_TT_DIAS_CONTROL { get; set; }
        public IEnumerable<WebTIGA.Models.SP_TT_ERROR_FASES_DISTRIBUCION_Result> SP_TT_ERROR_FASES_DISTRIBUCION { get; set; }
        public IEnumerable<WebTIGA.Models.Persona> Persona { get; set; }
        public IEnumerable<WebTIGA.Models.Usuario> Usuario { get; set; }
        public IEnumerable<WebTIGA.Models.UsuarioModuloRol> UsuarioModuloRol { get; set; }
        public IEnumerable<WebTIGA.Models.Rol> Rol { get; set; }
        public IEnumerable<WebTIGA.Models.Modulo> Modulo1 { get; set; }
        public IEnumerable<WebTIGA.Models.ModuloRol> ModuloRol { get; set; }
        public IEnumerable<WebTIGA.Models.VIEW_USUARIOS_FORGOT_PASSWORD> VIEW_USUARIOS_FORGOT_PASSWORD { get; set; }
        public IEnumerable<WebTIGA.Models.SP_MODULOS_USUARIOS_Result> SP_MODULOS_USUARIOS_Result { get; set; }
        public IEnumerable<WebTIGA.Models.SP_WT_ADMINISTRADOR_USUARIOS_Result> SP_WT_ADMINISTRADOR_USUARIOS_Result { get; set; }
        public IEnumerable<WebTIGA.Models.VIEW_WT_USUARIOS> VIEW_WT_USUARIOS { get; set; }

        public IEnumerable<WebTIGA.Models.SP_WT_ROLES_MODULO_Result> SP_WT_ROLES_MODULO_Result { get; set; }

    }



    public class JsonGRAFTiempos
    {
        public Int32? Porcentaje { get; set; }
    }
    public class JsonGRAFDiasxFase
    {
        public string Equipo { get; set; }
      
    }

    

    public class RecoveryViewModel
    {
        [Required]
        public string Usuario { get; set; }

        PROYECTOSIAV2Entities1 user = new PROYECTOSIAV2Entities1();

        public bool validar_usuario()

        {
            //var ContraseñaEncrypt = Encrypt.Base64_Encode(Contraseña);

            var query = from u in user.Usuario
                        where u.Usuario1 == Usuario 
                        select u;



            if (query.Count() > 0)
            {

                //var query2 = from u in user.DACW_Usuario_Login where u.Usuario == Usuario select u;
                var datos = query.ToList();
                foreach (var Data in datos)
                {
                  
                    Usuario = Data.Usuario1;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class RecoveryPasswordViewModel
    {
        public string token { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos de 6 caracteres")]
        public string Password { get; set; }

        [Compare("Password")]
        [Required]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos de 6 caracteres")]
        public string Password2 { get; set; }
    }

    public class UsuarioModuloRolViewModel1
    {

        public int IdUsuario { get; set; }
        public int IdModulo { get; set; }
        public int IdRol { get; set; }
        public int Estado { get; set; }

        public virtual ModuloRol ModuloRol { get; set; }
        public virtual Usuario Usuario { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebTIGA.Models
{
    public class UserLogin
    {

        public int ID { get; set; }
        public int? IDPersona { get; set; }

        [Required(ErrorMessage = " El usuario es requerido")]
        [Display(Name = "Usuario")]
        public String UsuarioWT { get; set; }

        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos de 6 caracteres")]
        [Required(ErrorMessage = " La contraseña es requerida")]
        [Display(Name = "Contraseña")]
        public string Contraseña { get; set; }
        public int? Rol { get; set; }
        public int? Modulo { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }

        PROYECTOSIAV2Entities user = new PROYECTOSIAV2Entities();
        public bool logeo()

        {
            //var ContraseñaEncrypt = Encrypt.Base64_Encode(Contraseña);

            var query = from u in user.Usuario
                        where u.Usuario1 == UsuarioWT && u.Contraseña == Contraseña
                        select u;


            
            if (query.Count() > 0)
            {

                //var query2 = from u in user.DACW_Usuario_Login where u.Usuario == Usuario select u;
                var datos = query.ToList();
                foreach (var Data in datos)
                {
                    ID = Data.IdUsuario;
                    IDPersona = Data.IdPersona;
                    UsuarioWT = Data.Usuario1;
                    Nombres = Data.Persona.Nombres;
                    Apellidos = Data.Persona.Apellidos;
                    
                    
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
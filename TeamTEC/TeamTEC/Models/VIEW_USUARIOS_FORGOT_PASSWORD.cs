//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebTIGA.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class VIEW_USUARIOS_FORGOT_PASSWORD
    {
        public int IdUsuario { get; set; }
        public int IdPersona { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public string token_recovery { get; set; }
        public string Email { get; set; }
    }
}

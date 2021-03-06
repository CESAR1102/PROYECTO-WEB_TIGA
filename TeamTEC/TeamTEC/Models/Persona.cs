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
    
    public partial class Persona
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Persona()
        {
            this.Usuario = new HashSet<Usuario>();
        }
    
        public int IdPersona { get; set; }
        public int IdCompañia { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Dni { get; set; }
        public int Activo { get; set; }
        public string Función { get; set; }
        public string Matrícula { get; set; }
        public string SubGerencia { get; set; }
        public string Equipo { get; set; }
        public Nullable<System.DateTime> FechaIngreso { get; set; }
        public string NombreSharepoint { get; set; }
        public Nullable<byte> Administrador { get; set; }
        public string NombreTC { get; set; }
        public string NombreSharepoint2 { get; set; }
        public string NombreSharepoint3 { get; set; }
        public string NombreSharepoint4 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}

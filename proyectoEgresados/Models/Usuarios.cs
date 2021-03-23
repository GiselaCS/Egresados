using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proyectoEgresados.Models
{
    public class Usuarios
    {
        public int Id { get; set; }

        
        public int Documento { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Tipodoc { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public int Celular { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [EmailAddress(ErrorMessage = "Debe ingresar un email valido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [RegularExpression("[MmFfOo]", ErrorMessage = "Solo puede ingresar una M o F")]
        public string Genero { get; set; }

        public string Aprendiz { get; set; }

        public string Egresado { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Areaformacion { get; set; }

        
        public DateTime Fechaegresado { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Barrio { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Departamento { get; set; }

       
        public DateTime Fecharegistro { get; set; }
        
    }
}
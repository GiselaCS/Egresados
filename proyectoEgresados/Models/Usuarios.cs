using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectoEgresados.Models
{
    public class Usuarios
    {
        public int Id { get; set; }
        public int Documento { get; set; }
        public string Tipodoc { get; set; }
        public string Nombre { get; set; }
        public int Celular { get; set; }
        public string Email { get; set; }
        public string Genero { get; set; }
        public bool Aprendiz { get; set; }
        public bool Egresado { get; set; }

        public string Areaformacion { get; set; }
        public DateTime Fechaegresado { get; set; }
        public string Direccion { get; set; }
        public string Barrio { get; set; }
        public string Ciudad { get; set; }
        public string Departamento { get; set; }
        public DateTime Fecharegistro { get; set; }
    }
}
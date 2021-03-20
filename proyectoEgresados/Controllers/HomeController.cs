using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proyectoEgresados.Models;

namespace proyectoEgresados.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            MantenimientoUsuarios ma = new MantenimientoUsuarios();
            return View(ma.RecuperarTodos());
            
        }
        public ActionResult Details(int id)
        {
            MantenimientoUsuarios ma = new MantenimientoUsuarios();
            Usuarios usu = ma.Recuperardoc(id);
            return View(usu);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            MantenimientoUsuarios ma = new MantenimientoUsuarios();
            Usuarios usu = new Usuarios
            {
                Documento = int.Parse(collection["usu_documento"].ToString()),
                Tipodoc= collection["usu_tipodoc"].ToString(),
                Nombre = collection["usu_nombre"].ToString(),
                Celular = int.Parse(collection["usu_celular"].ToString()),
                Email = collection["usu_email"].ToString(),
                Genero = collection["usu_genero"].ToString(),
                Aprendiz = bool.Parse(collection["usu_aprendiz"].ToString()),
                Egresado = bool.Parse(collection["usu_egresado"].ToString()),
                Areaformacion = collection["usu_areaformacion"].ToString(),
                Fechaegresado= DateTime.Parse(collection["usu_fechaegresado"].ToString()),
                Direccion = collection["usu_direccion"].ToString(),
                Barrio = collection["usu_barrio"].ToString(),
                Ciudad = collection["usu_ciudad"].ToString(),
                Departamento = collection["usu_departamento"].ToString(),
                Fecharegistro = DateTime.Parse(collection["usu_fecharegistro"].ToString())
                

            };
            ma.Alta(usu);
            return RedirectToAction("Index");
        }


    }
}
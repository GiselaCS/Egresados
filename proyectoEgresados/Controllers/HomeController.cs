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
            //MantenimientoUsuarios ma = new MantenimientoUsuarios();
            //Usuarios usu = ma.Recuperardoc(id);
            //return View(usu);
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
               
                Documento = int.Parse(collection["documento"]),
                Tipodoc = collection["tipodoc"],
                Nombre = collection["nombre"],
                Celular = int.Parse(collection["celular"]),
                Email = collection["email"],
                Genero = collection["genero"],
                //Aprendiz = bool.Parse(collection["aprendiz"].ToString()),
                //Egresado = bool.Parse(collection["egresado"].ToString()),
                Areaformacion = collection["areaformacion"],
                Fechaegresado= DateTime.Parse(collection["fechaegresado"].ToString()),
                Direccion = collection["direccion"],
                Barrio = collection["barrio"],
                Ciudad = collection["ciudad"],
                Departamento = collection["departamento"],
                Fecharegistro = DateTime.Parse(collection["fecharegistro"].ToString())
            };
            ma.Alta(usu);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            MantenimientoUsuarios ma = new MantenimientoUsuarios();
            Usuarios art = ma.Recuperardoc(id);
            return View(art);
        }
        public ActionResult BuscarId(FormCollection collection)
        {
            //MantenimientoUsuarios ma = new MantenimientoUsuarios();
            //return View(ma.Recuperardoc(Documento));
            MantenimientoUsuarios ma = new MantenimientoUsuarios();
            Usuarios dat = ma.Recuperardoc(int.Parse(collection["usu_documento"].ToString()));

            if (dat != null)
                return View("Details", dat);
            else
                return View("DatoNoExiste");
        }
        /*public ActionResult buscarid(FormCollection coleccion)
        {
            MantenimientoUsuarios ma = new MantenimientoUsuarios();
            Usuarios dat = ma.Recuperardoc(int.Parse(coleccion["usu_documento"].ToString()));

            if (dat != null)
                return View("Details", dat);
            else
                return View("DatoNoExiste");

        }*/


    }
}
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
        //funciona
        public ActionResult Index()
        {
            MantenimientoUsuarios ma = new MantenimientoUsuarios();
            return View(ma.RecuperarTodos());
            
        }
        //funciona
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
        //funciona
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
                Aprendiz = collection["aprendiz"],
                Egresado = collection["egresado"],
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
        //funciona
        /* public ActionResult Delete(int id)
         {
             MantenimientoUsuarios ma = new MantenimientoUsuarios();
             Usuarios usu = ma.Recuperardoc(id);
             return View(usu);
         }

         // POST: Home/Delete/5
         [HttpPost]
         public ActionResult Delete(int id, FormCollection collection)
         {
             MantenimientoUsuarios ma = new MantenimientoUsuarios();
             ma.Borrar(id);
             return RedirectToAction("Index");
         }*/
        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            MantenimientoUsuarios ma = new MantenimientoUsuarios();
            Usuarios usu = ma.Recuperardoc(id);
            return View(usu);
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            MantenimientoUsuarios ma = new MantenimientoUsuarios();
            ma.Borrar(id);
            return RedirectToAction("Index");

        }

        //funciona
        public ActionResult Edit(int id)
        {
            MantenimientoUsuarios ma = new MantenimientoUsuarios();
            Usuarios usu = ma.Recuperardoc(id);
            return View(usu);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            MantenimientoUsuarios ma = new MantenimientoUsuarios();
            Usuarios usu = new Usuarios
            {
                Id = id,
                //Documento= documento,
                Documento = int.Parse(collection["documento"].ToString()),
                Tipodoc = collection["tipodoc"].ToString(),
                Nombre = collection["nombre"].ToString(),
                Celular = int.Parse(collection["celular"].ToString()),
                Email = collection["email"].ToString(),
                Genero = collection["genero"].ToString(),
                Aprendiz = collection["aprendiz"].ToString(),
                Egresado = collection["egresado"].ToString(),
                Areaformacion = collection["areaformacion"].ToString(),
                Fechaegresado = DateTime.Parse(collection["fechaegresado"].ToString()),
                Direccion = collection["direccion"].ToString(),
                Barrio = collection["barrio"].ToString(),
                Ciudad = collection["ciudad"].ToString(),
                Departamento = collection["departamento"].ToString(),
                Fecharegistro = DateTime.Parse(collection["fecharegistro"].ToString())
            };
            ma.Modificar(usu);
            return RedirectToAction("Index");
        }
       
        //no funciona
        public ActionResult buscararea(FormCollection coleccion)
        {
            MantenimientoUsuarios ma = new MantenimientoUsuarios();
            Usuarios dat = ma.Recuperararea(coleccion["usu_areaformacion"]);

            if (dat != null)
                return View("Detallesarea", dat);
            else
                return View("NoExiste");

        }
        public ActionResult Detallesarea(string area)
        {
            //MantenimientoUsuarios ma = new MantenimientoUsuarios();
            //Usuarios usu = ma.Recuperardoc(id);
            //return View(usu);
            MantenimientoUsuarios ma = new MantenimientoUsuarios();
            Usuarios usu = ma.Recuperararea(area);
            return View(usu);
        }

    }
}
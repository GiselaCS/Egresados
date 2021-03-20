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

    }
}
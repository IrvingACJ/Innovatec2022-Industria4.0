using Innovatec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Innovatec.Controllers
{
    public class LineasComponentesBasculasController : Controller
    {
        DB_I4 db = new DB_I4();
        // GET: LineasComponentesBasculas
        public ActionResult Index()
        {
            var List = db.tLineasComponentesBasculas.AsEnumerable();
            return View(List);
        }
        public JsonResult List()
        {
            var List = from lcb in db.tLineasComponentesBasculas.AsEnumerable()
                       select new
                       {
                           Bascula = lcb.ID_Bascula,
                           Componente = lcb.tComponentes.Descripcion,
                           Linea = lcb.tLineasProduccion.Descripcion,
                           Cantidad = lcb.Cantidad,
                           Error = (lcb.Cantidad >= lcb.Maximo) ? "Componente llego a su Maximo." 
                                     :  (lcb.Cantidad <= lcb.Minimo) ? "Componente llego a su Minimo."
                                     :  ""
                       };
            return Json(List, JsonRequestBehavior.AllowGet);
        }

        // GET: LineasComponentesBasculas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LineasComponentesBasculas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LineasComponentesBasculas/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: LineasComponentesBasculas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LineasComponentesBasculas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: LineasComponentesBasculas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LineasComponentesBasculas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

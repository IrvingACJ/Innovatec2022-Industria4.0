using Innovatec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Innovatec.Controllers
{
    public class BasculasController : Controller
    {
        DB_I4 db = new DB_I4();
        // GET: Basculas
        public ActionResult Index()
        {
            var List = db.tBasculas.AsEnumerable();
            return View(List);
        }
        public JsonResult List()
        {
            var List = from b in db.tBasculas.AsEnumerable()
                             select new
                             {
                                 b.ID_Bascula,
                                 Ubicacion = b.Descripcion.Split(':')[0],
                                 Status = b.Descripcion.Split(':')[1]
                             };
            
            return Json(List, JsonRequestBehavior.AllowGet);
        }

        // GET: Basculas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Basculas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Basculas/Create
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

        // GET: Basculas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Basculas/Edit/5
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

        // GET: Basculas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Basculas/Delete/5
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

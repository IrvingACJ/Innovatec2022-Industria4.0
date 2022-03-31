using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Innovatec.Controllers
{
    public class ComponentesController : Controller
    {
        // GET: Componentes
        public ActionResult Index()
        {
            return View();
        }

        // GET: Componentes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Componentes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Componentes/Create
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

        // GET: Componentes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Componentes/Edit/5
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

        // GET: Componentes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Componentes/Delete/5
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

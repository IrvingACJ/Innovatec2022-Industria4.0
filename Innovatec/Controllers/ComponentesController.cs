using Innovatec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Innovatec.Controllers
{
    public class ComponentesController : Controller
    {
        DB_I4 db = new DB_I4();
        // GET: Componentes
        public ActionResult Index()
        {
            var List = db.tComponentes.ToList();
            return View(List);
        }

        // GET: Componentes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Componentes/Create
        public ActionResult Create()
        {
            tComponentes NewItem = new tComponentes();
            return View(NewItem);
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

using Innovatec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Innovatec.Class;
using System.Web.Routing;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

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
                                     : (lcb.Cantidad <= lcb.Minimo) ? "Componente llego a su Minimo."
                                     : ""
                       };
            List<Thread> LT = new List<Thread>();
            
            foreach (var item in List.Where(l => !String.IsNullOrEmpty(l.Error)))
            {
                string area = item.Linea.Split(new char[] { '_' }).FirstOrDefault();
                string home = Url.Action("Index", "Home",
                                            routeValues: new RouteValueDictionary(new { }), protocol: "http",
                                            hostName: Request.Url.DnsSafeHost);
                string carpeta = HttpContext.Server.MapPath("/Views/Emails");
                LT.Add(new Thread(() => SendNotifcations(home, carpeta,item.Componente, "jehusiqueiros@gmail.com", area)));
            }
            for (int i = 0; i < LT.Count(); i++)
            {
                LT[i].Start();
            }
            
            return Json(List, JsonRequestBehavior.AllowGet);
        }

        public void SendNotifcations(string home, string carpeta, string componente, string destinatario, string area) {
        Email Email = new Email();
            switch (area.ToLower())
            {
                case "almacen":
                    Email.Selector(home, Path.Combine( carpeta, "Almacen.html"),componente, destinatario);
                    Class.Telegram.Send_Message(componente, "proveedor").GetAwaiter();
                    Task Wait = new Task(() => Class.Telegram.Waiter(3));
                    Wait.Start();
                    Task.WaitAll(Wait);

                    break;
                case "linea":
                    Email.Selector(home, Path.Combine(carpeta, "Linea.html"), componente, destinatario);
                    Class.Telegram.Send_Message(componente, "almacen").GetAwaiter();
                    Task Wait2 = new Task(() => Class.Telegram.Waiter(3));
                    Wait2.Start();
                    Task.WaitAll(Wait2);
                    break;
            }
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

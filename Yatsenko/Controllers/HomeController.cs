using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Yatsenko.Models;
using Yatsenko.DAO;


namespace Yatsenko.Controllers
{
    public class HomeController : Controller
    {
        private Database1Entities6 _entities = new Database1Entities6(); 
        RouteDAO routeDAO = new RouteDAO();


        public ActionResult Index(string stopName)
        {
            var search = from s in _entities.Routes select s;
            if (!String.IsNullOrEmpty(stopName))
            {
                search = search.Where(c => c.firstStop.Contains(stopName));
            }
            return View(search);
        }
        //
        // GET: /Home/Details/5
        
        public ActionResult Details(int id)
        {
            var route = routeDAO.getAllRoutes().First(m => m.IdRoute == id);
            if (route != null)
            {
                return View("Details", route);
            }
            else
            {
                return HttpNotFound();
            }
        }
        //
        // GET: /Home/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            Route r = new Route();
            r.IdRoute = 0;
            r.firstStop = null;
            r.lastStop = null;
            r.dateLimit = DateTime.Now.AddDays(30);
            return View("Create", r);
        }
        //
        // POST: /Home/Create
        [AcceptVerbs(HttpVerbs.Post)]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create(Route route)
        {
            try
            {
                string tmp2 = route.count.ToString();
                if (string.IsNullOrEmpty(route.firstStop))
                {
                    ModelState.AddModelError("firstStop", "Поле 'первая остановка' обязательно для заполнения");
                } 
                if (string.IsNullOrEmpty(route.lastStop))
                    {
                        ModelState.AddModelError("lastStop", "Поле 'конечная остановка' обязательно для заполнения");
                    }
                if (string.IsNullOrEmpty(tmp2))
                {
                    ModelState.AddModelError("count", "Поле 'Количество билетов' обязательно для заполнения");
                }
                if (ModelState.IsValid && routeDAO.addRoute(route))

                    return RedirectToAction("Index");
                else
                    return View("Create");
            }
            catch
            {
                return View("Create");
            }
        }
        //
        // GET: /Home/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id)
        {
            var route = routeDAO.getAllRoutes().First(m => m.IdRoute == id);
            ViewData.Model = route;
            return View();
        }
        //
        // POST: /Home/Edit/5
        [AcceptVerbs(HttpVerbs.Post)]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id, FormCollection collection)
        {

            try
            {
                var route = routeDAO.getAllRoutes().First(m => m.IdRoute == id);
                UpdateModel(route);
                routeDAO.editRoute(route);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: /Movies/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var route = routeDAO.getAllRoutes().First(m => m.IdRoute == id);
            if (route == null)
            {
                return HttpNotFound();
            }
            return View(route);
        }

        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
       // [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteConfirmed(int id)
        {
            
            try
            {
                var route = routeDAO.getAllRoutes().First(m => m.IdRoute == id);
                routeDAO.deleteRoute(route);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult SearchForFirstStop(string stopName)
        {
            var stops = from s in _entities.Routes select s;
            if (!String.IsNullOrEmpty(stopName))
            {
                stops = stops.Where(c => c.firstStop.Contains(stopName));
            }
            return View();
        }
    }
}

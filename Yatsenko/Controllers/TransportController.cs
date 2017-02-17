 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Data.Entity;
using System.Data;
using System.Data.SqlClient;
using Yatsenko.Models;
using Yatsenko.DAO;


namespace Yatsenko.Controllers
{
    public class TransportController : Controller
    {
       
       TransportDAO transportDAO = new TransportDAO();
       RouteDAO routeDAO = new RouteDAO();

       readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        
        public ActionResult Index(int? id)
       {
           logger.Debug("TRANSPORT PARALLEL  LOG");
            ViewData["route"] = routeDAO.getAllRoutes();
            return View(transportDAO.getAllTransports());
        }

        public ActionResult Details(int id)
        {
            return View(transportDAO.getTransport(id));
           
        }

        protected bool ViewDataSelectList(int idRoute)
        {
            var route = routeDAO.getAllRoutes();
            ViewData["idRoute"] = new SelectList(route, "idRoute", "idRoute", idRoute);
            return route.Count() > 0;
        }

        [Authorize(Roles = "Administrator, Dispetcher")]
        public ActionResult Create()
        {
            if (!ViewDataSelectList(-1))
                return RedirectToAction("Index");
            return View("Create");
        }

        [Authorize(Roles = "Administrator, Dispetcher")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(int idRoute, [Bind(Exclude = "IdRoute")] Transport transport)
        {
            try
            {
                if (transportDAO.addTransport(idRoute, transport))
                    return RedirectToAction("Index");
                else
                {
                    ViewDataSelectList(idRoute);
                    return View("Create");
                }
                   
            }
            catch
            {
                return View("Create");
            }
        }

        [Authorize(Roles = "Administrator, Dispetcher")]
        public ActionResult Edit(int id)
        {
            Transport transport = transportDAO.getTransport(id);
            if (!ViewDataSelectList(Convert.ToInt32(transport.Route.IdRoute)))
                return RedirectToAction("Index");
            return View(transportDAO.getTransport(id));
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int idRoute, int id, Transport transport)
        {

            if (transportDAO.editTransport(idRoute, transport))
                return RedirectToAction("Index");
            else
            {
                ViewDataSelectList(-1);
                return View("Edit", transportDAO.getTransport(id));
            }
        }

        [Authorize(Roles = "Administrator, Dispetcher")]
        public ActionResult Delete(int id)
        {
            return View("Delete", transportDAO.getTransport(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id, Transport transport)
        {

            if (transportDAO.deleteTransport(id))
                return RedirectToAction("Index");
            else return View("Delete", transportDAO.getTransport(id));

        }
    }
}

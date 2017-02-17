using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.WebData;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Data.Entity;
using System.Data;
using System.Data.SqlClient;
using Yatsenko.Models;
using Yatsenko.DAO;

namespace Yatsenko.Controllers
{
    public class TicketController : Controller
    {
        //
        // GET: /Contact/
        TicketDAO ticketDAO = new TicketDAO();
        RouteDAO routeDAO = new RouteDAO();

        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [Authorize(Roles = "Client, Dispetcher, Administrator")]
        public ActionResult Index(int? id)
        {
            logger.Debug("TICKET PARALLEL  LOG");
            ViewData["route"] = routeDAO.getAllRoutes();
            return View(ticketDAO.getAllTickets());
        }

        [Authorize(Roles = "Client, Dispetcher, Administrator")]
        public ActionResult Details(int id)
        {
            return View(ticketDAO.getTicket(id));

        }


        protected bool ViewDataSelectList(int idRoute)
        {
            var route = routeDAO.getAllRoutes();
            ViewData["idRoute"] = new SelectList(route, "IdRoute", "number", idRoute);
            return route.Count() > 0;
        }

        [Authorize(Roles = "Client, Dispetcher, Administrator")]
        public ActionResult CreateBron(int id)
        {
            Ticket t = new Ticket();
            t.idRoute = id;
            t.condition = "Забронирован";
            t.idUser = WebSecurity.CurrentUserId;
            if (!ViewDataSelectList(-1))
                return RedirectToAction("Index");
            return View("Create", t);
        }

        [Authorize(Roles = "Client, Dispetcher, Administrator")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateBron(int idRoute, [Bind(Exclude = "IdRoute")] Ticket ticket)
        {
            try
            {
                if (ticketDAO.addBronTicket(idRoute, ticket))
                    return RedirectToAction("Index");
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [Authorize(Roles = "Client, Dispetcher, Administrator")]
        public ActionResult CreateBought(int id)
        {
            Ticket t = new Ticket();
            t.idRoute = id;
            t.condition = "Куплен";
            t.idUser = WebSecurity.CurrentUserId;
            if (!ViewDataSelectList(-1))
                return RedirectToAction("Index", "Home");
            return View("Create", t);
        }


        [Authorize(Roles = "Client, Dispetcher, Administrator")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateBought(int idRoute, [Bind(Exclude = "IdRoute")] Ticket ticket)
        {
            try
            {
                if (ticketDAO.addBoughtTicket(idRoute, ticket))
                    return RedirectToAction("Index");
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [Authorize(Roles = "Dispetcher, Client")]
        public ActionResult Edit(int id)
        {
            Ticket ticket = ticketDAO.getTicket(id);
            if (!ViewDataSelectList(Convert.ToInt32(ticket.Route.IdRoute)))
                return RedirectToAction("Index");
            return View(ticketDAO.getTicket(id));
        }


        [AcceptVerbs(HttpVerbs.Post)]
        [Authorize(Roles = "Dispetcher, Client")]
        public ActionResult Edit(int idRoute, int id, Ticket ticket)
        {
            if (ticketDAO.editTicket(idRoute, ticket))
                return RedirectToAction("Index");
            else
            {
                ViewDataSelectList(-1);
                return View("Edit", ticketDAO.getTicket(id));
            }
        }

        public ActionResult Delete(int id)
        {
            return View("Delete", ticketDAO.getTicket(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id, Ticket ticket)
        {

            if (ticketDAO.deleteTicket(id))
                return RedirectToAction("Index");
            else return View("Delete", ticketDAO.getTicket(id));

        }
    }
}

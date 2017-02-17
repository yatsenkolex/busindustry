using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Data.EntityModel;
using System.Data;
using System.Data.Objects;
using System.Data.SqlClient;
using Yatsenko.Models;
using Yatsenko.DAO;

namespace Yatsenko.DAO
{
    public class TicketDAO
    {
        private Database1Entities6 _entities = new Database1Entities6();

        public IEnumerable<Ticket> getAllTickets()
        {
            return (from c in _entities.Tickets select c);
        }

        public Route GetTicketRoute(int? id)
        {
            if (id != null)
                return (from c in _entities.Routes where c.IdRoute == id select c).FirstOrDefault();
            else
                return (from c in _entities.Routes select c).FirstOrDefault();
        }

        public Ticket getTicket(int id)
        {
            return (from c in _entities.Tickets.Include("Route") where c.IdTicket == id select c).FirstOrDefault();
        }

        public IEnumerable<Ticket> getTicketByRoute(int id)
        {
            return (from c in _entities.Tickets.Include("Route") where c.idRoute == id select c);
        }

        public bool addBronTicket(int idRoute, Ticket ticket)
        {
            try
            {
                ticket.Route = GetTicketRoute(idRoute);
                RouteDAO routeDAO = new RouteDAO();
                Route oldRoute = _entities.Routes.Find(idRoute);
                if (oldRoute.count <= 0)
                {
                    return false;
                }
                else
                {
                    oldRoute.count = oldRoute.count - 1;
                    _entities.Tickets.Add(ticket);
                    _entities.Entry(oldRoute).State = EntityState.Modified;
                    _entities.SaveChanges();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool addBoughtTicket(int idRoute, Ticket ticket)
        {
            try
            {
                ticket.Route = GetTicketRoute(idRoute);
                RouteDAO routeDAO = new RouteDAO();
                Route oldRoute = _entities.Routes.Find(idRoute);
                if (oldRoute.count <= 0)
                {
                    return false;
                }
                else
                {
                    oldRoute.count = oldRoute.count - 1;
                    _entities.Tickets.Add(ticket);
                    _entities.Entry(oldRoute).State = EntityState.Modified;
                    _entities.SaveChanges();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool editTicket(int TicketID, Ticket ticket)
        {

            try
            {
                _entities.Entry(ticket).State = EntityState.Modified;
                _entities.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool deleteTicket(int id)
        {
            RouteDAO routeDAO = new RouteDAO();
            Ticket ticket = selectTicket(id);
            try
            {
                Route oldRoute = _entities.Routes.Find(ticket.idRoute);
                oldRoute.count = oldRoute.count + 1;
                _entities.Entry(oldRoute).State = EntityState.Modified;
                _entities.Tickets.Remove(ticket);
                _entities.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public Ticket selectTicket(int id)
        {
            return (_entities.Tickets.Find(id));
        }
    }
}
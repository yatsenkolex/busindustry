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
    public class TransportDAO
    {
        private Database1Entities6 _entities = new Database1Entities6();

        public IEnumerable<Transport> getAllTransports() 
        {
            return (from c in _entities.Transports select c);
        }

        public Route GetTransportRoute(int? id) 
        {
            if (id != null)
                return (from c in _entities.Routes where c.IdRoute == id select c).FirstOrDefault();
            else
                return (from c in _entities.Routes select c).FirstOrDefault();
        }

        public Transport getTransport(int id) 
        {
            return (from c in _entities.Transports.Include("Route") where c.IdTransport == id select c).FirstOrDefault();
        }

        public IEnumerable<Transport> getTransportByRoute(int id)  
        {
            return (from c in _entities.Transports.Include("Route") where c.idRoute == id select c);
        }

        public bool addTransport(int RouteID, Transport transport) 
        {
            try
            {
                transport.Route = GetTransportRoute(RouteID);
                _entities.Transports.Add(transport); 
                _entities.SaveChanges(); 
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool editTransport(int TransportID, Transport transport)
        {
            try
            {
                _entities.Entry(transport).State = EntityState.Modified; 
                _entities.SaveChanges(); 
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool deleteTransport(int id) 
        {
            Transport transport = selectTransport(id); 

            try
            {
                _entities.Transports.Remove(transport); 
                _entities.SaveChanges(); 
            }
            catch
            {
                return false;
            }
            return true;
        }
        public Transport selectTransport(int id)
        {
            return (_entities.Transports.Find(id));
        }
    }
}
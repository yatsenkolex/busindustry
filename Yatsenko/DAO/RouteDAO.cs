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
    public class RouteDAO
    {
        private Database1Entities6 _entities = new Database1Entities6(); 

        public IEnumerable<Route> getAllRoutes() 
        {
            return (from c in _entities.Routes select c); 
        }


        public bool addRoute(Route route) 
        {
            try
            {
                _entities.Routes.Add(route); 
                _entities.SaveChanges(); 
            }
            catch
            {
                return false;
            }
            return true;
        }

        public Route getRoute(int id) 
        {
            return (from c in _entities.Routes where c.IdRoute == id select c).FirstOrDefault();
        }

        public bool editRoute(Route route) 
        {
            Route originalRoute = getRoute(Convert.ToInt32(route.IdRoute)); 
            try
            { 
                _entities.Entry(originalRoute).State = EntityState.Modified; 
                _entities.SaveChanges(); 
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool deleteRoute(Route route) 
        {
            Route originalRoute = getRoute(Convert.ToInt32(route.IdRoute)); 

            try
            {
                _entities.Routes.Remove(originalRoute); 
                _entities.SaveChanges(); 
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
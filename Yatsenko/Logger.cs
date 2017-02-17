using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
using log4net.Config;


namespace Yatsenko
{
    public class Logger
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Logger));

        public static ILog Log
        {
            get { return log; }
        }

        public static void InitLogger()
        {
            XmlConfigurator.Configure();
        }

        static void Main(string[] args)
        {
            log.Debug("Here is a debug log.");
            log.Info(" ... and an Info log.");
            log.Warn("... and a warning.");
            log.Error("... and an error.");
            log.Fatal("... and a fatal error.");
        }
    }
}
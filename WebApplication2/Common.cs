using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayer2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using NLog;

namespace WebApplication2
{
    public class Common
    {

        public static Employees Employee = new Employees();

        public static Salarys Salary = new Salarys();



        public class Log
        {
            private static readonly Logger _logger = new LogFactory().GetCurrentClassLogger();

            public static void Error(Exception ex)
            {
                System.Diagnostics.Trace.TraceError(ex.ToString());
                _logger.Error(ex);
            }
            public static void Error(string ex)
            {
                System.Diagnostics.Trace.TraceError(ex.ToString());
                _logger.Error(ex);
            }

            public static void Info(string message)
            {
                _logger.Info(message);
            }
        }

        public class Paths
        {
            public static string GalleryRootFolderName => "Uploads";
            public static string GalleryRoot => MyRoot + GalleryRootFolderName + "/";
        }

        public static string MyRoot
        {
            get
            {
                return HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority +
    HttpContext.Current.Request.ApplicationPath.TrimEnd('/') +
    "/";
            }
        }
        public class CommonObjects
        {
            public string Heading { get; set; }
           
        }
    }

    
}
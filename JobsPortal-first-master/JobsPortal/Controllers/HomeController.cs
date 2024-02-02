using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseAccessLayer;
using log4net;

namespace JobsPortal.Controllers
{
    public class HomeController : Controller
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        // GET: Home
        private JobsPortalDbEntities db = new JobsPortalDbEntities();
        public ActionResult Index()
        {
            log.Info("Accessed HomeController's Index action.");
            return View();
        }
        public ActionResult About()
        {
            log.Info("Accessed HomeController's About action.");
            return View();
        }
        public ActionResult Contact()
        {
            log.Info("Accessed HomeController's Contact action.");
            return View();
        }
        public ActionResult Search(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                // Handle the case when no keyword is provided
                return View("Index");
            }

            // Perform the search based on the keyword
            var searchResults = db.PostJobTables
                .Where(job => job.JobTitle.Contains(keyword) || job.JobDescription.Contains(keyword))
                .ToList();

            // Pass the search results back to the Index view
            return View("Index", searchResults);
        }
    }

}
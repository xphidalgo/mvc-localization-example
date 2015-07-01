using Routing.Filters;
using Routing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Routing.Controllers
{
    
    public class UtilsController : Controller
    {
        // GET: Utils
        [SkipCultureAttribute]
        public ActionResult Redirect()
        {
            var languageRepo = new LanguageRepository();
            
            var language = languageRepo.getAvailable().First();

            return RedirectToAction("Index", "Home", new { language = language.getSlug() });
        }
    }
}
using Routing.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Routing.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class CultureAttribute : ActionFilterAttribute
    {
        

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.ActionDescriptor.GetCustomAttributes(typeof(SkipCultureAttribute), false).Any())
            {
                return;
            }

            string currentLanguage = filterContext.RouteData.Values["language"].ToString();

            var languagesRepo = new LanguageRepository();

            var language = languagesRepo.getBySlug(currentLanguage);

            if (language == null)
            { 
                filterContext.Result = new HttpStatusCodeResult(404);
            }
            else
            { 
                // Set culture on current thread
                SetCultureOnThread(language.Culture);

                // Proceed as usual
                base.OnActionExecuting(filterContext);
            }
        }

        private static void SetCultureOnThread(String language)
        {
            var cultureInfo = CultureInfo.CreateSpecificCulture(language);
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }
    }
}
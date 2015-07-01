using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Routing.Models
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Culture { get; set; }
        public string getSlug()
        {
            return Culture.Substring(0, 2);
        }
    }
    public static class LanguageHelper
    {
        public static List<Language> getAll()
        {
            if(HttpContext.Current.Cache["languages"] == null)
            {
                var languageRepo = new LanguageRepository();

                HttpContext.Current.Cache["languages"] = languageRepo.getAvailable();
            }
            return (List<Language>)HttpContext.Current.Cache["languages"];
        }
    }
    public class LanguageRepository
    {
        public List<Language> getAvailable()
        {
            int index = 0;
            return new List<Language> {
                new Language { 
                    Id = index++,
                    Culture = "en-US",
                    Name    = "English"
                },
                new Language { 
                    Id = index++,
                    Culture = "es-ES",
                    Name    = "Español"
                },
                new Language { 
                    Id = index++,
                    Culture = "pt-BR",
                    Name    = "Portuguese"
                }
            };
        }
        public Language getBySlug(string slug)
        {
            return this.getAvailable().Where(x => x.getSlug().Equals(slug)).FirstOrDefault();
        }
    }
}
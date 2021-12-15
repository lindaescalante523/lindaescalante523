using Sabio.Models.Assessment;
using Sabio.Models.Requests;
using Sabio.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabio.Services
{
    public class AssessmentService : IAssessmentService
    {
      
    
        public string Generate(string url)
        {

            string shortUrl = String.Format("{0:X}", url.GetHashCode());

            Assessment assessment = new Assessment();
            assessment.shortUrl = shortUrl;
            assessment.url = url;

            Dictionary<string, Assessment> cache = new Dictionary<string, Assessment>();

            cache.Add(shortUrl, assessment);

            return shortUrl;
        }

        public string GetShortUrl(string shortUrl)
        {
            string url = null;
         
            return url;
        }

   

  

    }


}
using Sabio.Models.Assessment;
using Sabio.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabio.Services.Interfaces
{
    public interface IAssessmentService
    {
        
        string GetShortUrl(string shortUrl);

        string Generate(string url);
    }
}

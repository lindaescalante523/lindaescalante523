using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sabio.Models.Requests;
using Sabio.Services.Interfaces;
using Sabio.Web.Models;
using Sabio.Web.Models.Responses;
using System;

namespace Sabio.Web.Api.Controllers
{
    [Route("api/assessment")]
    [ApiController]
    public class AssessmentAPIController : ControllerBase
    {
        private IAssessmentService _service = null;
        public AssessmentAPIController(IAssessmentService service,
            ILogger<AssessmentAPIController> logger)
        {
            _service = service;
        }


        [HttpGet("generate")]
        [AllowAnonymous]
        public ActionResult<ItemResponse<string>> GetShortUrl(string url)
        {
            int iCode = 200;
            BaseResponse response = null;

            try
            {
                string shortUrl = _service.Generate(url);

                response = new ItemResponse<string> { Item = shortUrl };

            }
            catch (Exception ex)
            {
                iCode = 500;
                response = new ErrorResponse($"Generic Error: {ex.Message}");
            }

            return StatusCode(iCode, response);
        }

        //[HttpPost]
        //public ActionResult<ItemResponse<string>> Create(AssessmentAddRequest model)
        //{
        //    ObjectResult result = null;

        //    try
        //    {


        //        string url = _service.Generate(model);

        //        ItemResponse<string> response = new ItemResponse<string>() { Item = url };
        //        result = Created201(response);
        //    }
        //    catch (Exception ex)
        //    {

        //        ErrorResponse response = new ErrorResponse(ex.Message);

        //        result = StatusCode(500, response);
        //    }

        //    return result;
        //}
        //protected CreatedResult Created201(IItemResponse response)
        //{
        //    string url = Request.Path + "/" + response.Item.ToString();

        //    return base.Created(url, response);
        //}
    }
}



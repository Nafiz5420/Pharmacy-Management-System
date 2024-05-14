using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Seller.Controllers
{
    public class SelectionController : ApiController
    {
        [HttpGet]
        [Route("api/Selection")]
        public HttpResponseMessage Selection()
        {
            try
            {
                var data = SelectionService.GET();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}

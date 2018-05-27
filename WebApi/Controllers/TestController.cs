using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AspNetProjectStructure.Controllers
{
    [RoutePrefix("api/Test")]
    public class TestController : ApiController
    {
        [HttpGet]
        [Route("Index")]
        public HttpResponseMessage Index()
        {
            var r1 = Url.Link("Default", new {controller = "Test", action = "Index"});
            var r2 = Url.Link("DefaultAPi", new {controller = "Test", action = "Index"});
            var r3 = Url.Link("HelpPage_Default", new {controller = "Help", action = "Index"});

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
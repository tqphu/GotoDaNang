using GotoDaNang.Services;
using GotoDaNang.Web.Infrastructure.Core;
using System.Web.Http;

namespace GotoDaNang.Web.API
{
    [RoutePrefix("api/home")]
    public class HomeController : ApiControllerBase
    {
        IErrorService _errorService;
        public HomeController(IErrorService errorService) : base(errorService)
        {
            this._errorService = errorService;
        }

        [HttpGet]
        [Route("TestMethod")]
        public string TestMethod()
        {
            return "Hello, My name is Phú Đẹp Trai ";
        }
    }
}
using GotoDaNang.Services;
using GotoDaNang.Web.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GotoDaNang.Web.API
{
    [RoutePrefix("api/servicecontroller")]
    public class ServiceController : ApiControllerBase
    {
        IServiceService _serviceService;

        public ServiceController(IErrorService errorService, IServiceService serviceService) :
            base(errorService)
        {
            this._serviceService = serviceService;
        }


    }
}

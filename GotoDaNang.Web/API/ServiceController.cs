﻿using AutoMapper;
using GotoDaNang.Model.Model;
using GotoDaNang.Services;
using GotoDaNang.Web.Infrastructure.Core;
using GotoDaNang.Web.Infrastructure.Extensions;
using GotoDaNang.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace GotoDaNang.Web.API
{
    [RoutePrefix("api/service")]
    [Authorize]
    public class ServiceController : ApiControllerBase
    {
        IServiceService _serviceService;
        ICategoryService _categoryService;

        public ServiceController(IErrorService errorService, IServiceService serviceService, ICategoryService categoryService) :
            base(errorService)
        {
            this._serviceService = serviceService;
            this._categoryService = categoryService;
        }

        [Route("getallparents")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _categoryService.GetAll();

                var responseData = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("getcategorybyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetCategoryById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _serviceService.GetCategoryById(id);

                var responseData = Mapper.Map<IEnumerable<Service>, IEnumerable<ServiceViewModel>>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword = "", int page = 1, int pageSize = 10)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _serviceService.GetAll(keyword);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.Title).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<Service>, IEnumerable<ServiceViewModel>>(query);

                var paginationSet = new PaginationSet<ServiceViewModel>()
                {
                    Items = responseData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetbyID(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>

            {
                var model = _serviceService.GetById(id);
                var responseData = Mapper.Map<Service, ServiceViewModel>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            }
            );
        }

        [Route("add")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Post(HttpRequestMessage request, ServiceViewModel ServiceVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    Service newService = new Service();
                    newService.UpdateService(ServiceVm);

                    var Service = _serviceService.Add(newService);
                    _serviceService.Save();

                    var responseData = Mapper.Map<Service, ServiceViewModel>(newService);

                    response = request.CreateResponse(HttpStatusCode.Created, responseData);

                }
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Put(HttpRequestMessage request, ServiceViewModel ServiceVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var ServiceDb = _serviceService.GetById(ServiceVm.ID);
                    ServiceDb.UpdateService(ServiceVm);
                    _serviceService.Update(ServiceDb);
                    _serviceService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }

        [Route("delete")]
        [HttpDelete]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var oldService = _serviceService.Delete(id);
                    _serviceService.Save();
                    var responseData = Mapper.Map<Service, ServiceViewModel>(oldService);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);

                }
                return response;
            });
        }

        [Route("deletemulti")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedServices)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var listService = new JavaScriptSerializer().Deserialize<List<int>>(checkedServices);
                    foreach (var item in listService)
                    {
                        _serviceService.Delete(item);
                    }

                    _serviceService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK, listService.Count);
                }

                return response;
            });
        }
    }
}

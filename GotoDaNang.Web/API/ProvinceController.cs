using AutoMapper;
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
    [RoutePrefix("api/Province")]
    public class ProvinceController : ApiControllerBase
    {
        IProvinceService _provinceService;
        ICityService _cityService;

        public ProvinceController(IErrorService errorService, IProvinceService ProvinceService, ICityService cityService) :
            base(errorService)
        {
            this._provinceService = ProvinceService;
            this._cityService = cityService;
        }

        [Route("getallparents")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _cityService.GetAll();

                var responseData = Mapper.Map<IEnumerable<City>, IEnumerable<CityViewModel>>(model);

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
                var model = _provinceService.GetAll(keyword);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.Name).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<Province>, IEnumerable<ProvinceViewModel>>(query);

                var paginationSet = new PaginationSet<ProvinceViewModel>()
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
                var model = _provinceService.GetById(id);
                var responseData = Mapper.Map<Province, ProvinceViewModel>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            }
            );
        }

        [Route("add")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Post(HttpRequestMessage request, ProvinceViewModel ProvinceVm)
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
                    Province newProvince = new Province();
                    newProvince.UpdateProvince(ProvinceVm);

                    var Province = _provinceService.Add(newProvince);
                    _provinceService.Save();

                    var responseData = Mapper.Map<Province, ProvinceViewModel>(newProvince);

                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Put(HttpRequestMessage request, ProvinceViewModel ProvinceVm)
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
                    var ProvinceDb = _provinceService.GetById(ProvinceVm.ID);
                    ProvinceDb.UpdateProvince(ProvinceVm);
                    _provinceService.Update(ProvinceDb);
                    _provinceService.Save();

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
                    var oldProvince = _provinceService.Delete(id);
                    _provinceService.Save();
                    var responseData = Mapper.Map<Province, ProvinceViewModel>(oldProvince);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("deletemulti")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedCategories)
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
                    var listProvince = new JavaScriptSerializer().Deserialize<List<int>>(checkedCategories);
                    foreach (var item in listProvince)
                    {
                        _provinceService.Delete(item);
                    }

                    _provinceService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK, listProvince.Count);
                }
                return response;
            });
        }
    }
}

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
    [RoutePrefix("api/city")]
    [Authorize]
    public class CityController : ApiControllerBase
    {
        ICityService _cityService;
        IProvinceService _provinceService;


        public CityController(IErrorService errorService, ICityService cityService, IProvinceService provinceService) :
            base(errorService)
        {
            this._cityService = cityService;
            this._provinceService = provinceService;
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword = "", int page = 1, int pageSize = 10)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _cityService.GetAll(keyword);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.Name).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<City>, IEnumerable<CityViewModel>>(query);

                var paginationSet = new PaginationSet<CityViewModel>()
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
                var model = _cityService.GetById(id);
                var responseData = Mapper.Map<City, CityViewModel>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            }
            );
        }

        [Route("add")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Post(HttpRequestMessage request, CityViewModel CityVm)
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
                    City newCity = new City();
                    newCity.UpdateCity(CityVm);

                    var City = _cityService.Add(newCity);
                    _cityService.Save();

                    var responseData = Mapper.Map<City, CityViewModel>(newCity);

                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Put(HttpRequestMessage request, CityViewModel CityVm)
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
                    var CityDb = _cityService.GetById(CityVm.ID);
                    CityDb.UpdateCity(CityVm);
                    _cityService.Update(CityDb);
                    _cityService.Save();

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
                    var oldCity = _cityService.Delete(id);
                    _cityService.Save();
                    var responseData = Mapper.Map<City, CityViewModel>(oldCity);
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
                    var listCity = new JavaScriptSerializer().Deserialize<List<int>>(checkedCategories);
                    foreach (var item in listCity)
                    {
                        _cityService.Delete(item);
                    }

                    _cityService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK, listCity.Count);
                }
                return response;
            });
        }
    }
}

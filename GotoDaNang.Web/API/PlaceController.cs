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
    [RoutePrefix("api/place")]
    [Authorize]
    public class PlaceController : ApiControllerBase
    {
        //IServiceService _serviceService;
        //ICategoryService _placeService;
        IPlaceService _placeService;

        public PlaceController(IErrorService errorService, IPlaceService placeService) :
            base(errorService)
        {
            this._placeService = placeService;
        }

        [Route("getallparents")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _placeService.GetAll();

                var responseData = Mapper.Map<IEnumerable<Place>, IEnumerable<PlaceViewModel>>(model);

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
                var model = _placeService.GetAll(keyword);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.Title).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<Place>, IEnumerable<PlaceViewModel>>(query);

                var paginationSet = new PaginationSet<PlaceViewModel>()
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
                var model = _placeService.GetById(id);
                var responseData = Mapper.Map<Place, PlaceViewModel>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            }
            );
        }

        [Route("add")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Post(HttpRequestMessage request, PlaceViewModel placeViewModel)
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
                    Place newplace = new Place();
                    newplace.UpdatePlace(placeViewModel);

                    var Place = _placeService.Add(newplace);
                    _placeService.Save();

                    var responseData = Mapper.Map<Place, PlaceViewModel>(newplace);

                    response = request.CreateResponse(HttpStatusCode.Created, responseData);

                }
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Put(HttpRequestMessage request, PlaceViewModel placeViewModel)
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
                    var PlaceDb = _placeService.GetById(placeViewModel.ID);
                    PlaceDb.UpdatePlace(placeViewModel);
                    _placeService.Update(PlaceDb);
                    _placeService.Save();

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
                    var oldPlace = _placeService.Delete(id);
                    _placeService.Save();
                    var responseData = Mapper.Map<Place, PlaceViewModel>(oldPlace);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);

                }
                return response;
            });
        }

        [Route("deletemulti")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedPlaces)
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
                    var listPlace = new JavaScriptSerializer().Deserialize<List<int>>(checkedPlaces);
                    foreach (var item in listPlace)
                    {
                        _placeService.Delete(item);
                    }

                    _placeService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK, listPlace.Count);
                }

                return response;
            });
        }
    }
}

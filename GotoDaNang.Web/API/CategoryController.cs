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
    [RoutePrefix("api/category")]
    [Authorize]
    public class CategoryController : ApiControllerBase
    {
        ICategoryService _categoryService;
        IServiceService _serviceService;
        public CategoryController(IErrorService errorService, ICategoryService categoryService, IServiceService serviceService) :
            base(errorService)
        {
            this._categoryService = categoryService;
            this._serviceService = serviceService;
        }

        public HttpResponseMessage GetService(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _serviceService.GetAll();
                var query = model.Where(m => m.ID == id).ToList();
                var responseData = Mapper.Map<IEnumerable<Service>, IEnumerable<ServiceViewModel>>(query);
                var paginationSet = new PaginationSet<ServiceViewModel>()
                {
                    Items = responseData,

                };
                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
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
                var model = _categoryService.GetAll(keyword);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.Title).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(query);

                var paginationSet = new PaginationSet<CategoryViewModel>()
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
                var model = _categoryService.GetById(id);
                var responseData = Mapper.Map<Category, CategoryViewModel>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            }
            );
        }

        [Route("add")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Post(HttpRequestMessage request, CategoryViewModel categoryVm)
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
                    Category newCategory = new Category();
                    newCategory.UpdateCategory(categoryVm);

                    var category = _categoryService.Add(newCategory);
                    _categoryService.Save();

                    var responseData = Mapper.Map<Category, CategoryViewModel>(newCategory);

                    response = request.CreateResponse(HttpStatusCode.Created, responseData);

                }
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Put(HttpRequestMessage request, CategoryViewModel categoryVm)
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
                    var categoryDb = _categoryService.GetById(categoryVm.ID);
                    categoryDb.UpdateCategory(categoryVm);
                    _categoryService.Update(categoryDb);
                    _categoryService.Save();

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
                    var oldCategory =  _categoryService.Delete(id);
                    _categoryService.Save();
                    var responseData = Mapper.Map<Category, CategoryViewModel>(oldCategory);
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
                    var listCategory = new JavaScriptSerializer().Deserialize<List<int>>(checkedCategories);
                    foreach (var item in listCategory)
                    {
                        _categoryService.Delete(item);
                    }

                    _categoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK, listCategory.Count);
                }

                return response;
            });
        }
    }
}

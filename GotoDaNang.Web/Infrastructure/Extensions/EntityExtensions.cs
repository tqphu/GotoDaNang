using GotoDaNang.Model.Model;
using GotoDaNang.Web.Models;

namespace GotoDaNang.Web.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdateCategory(this Category category, CategoryViewModel categoryVm)
        {
            category.ID = categoryVm.ID;
            category.Event = categoryVm.Event;
            category.Government = categoryVm.Government;
            category.Title = categoryVm.Title;
            category.Avatar = categoryVm.Avatar;
            category.Icon = categoryVm.Icon;
            category.Status = categoryVm.Status;
        }

        public static void UpdateService(this Service service, ServiecViewModel serviecViewModel)
        {
            service.ID = serviecViewModel.ID;
            service.CategoryID = serviecViewModel.CategoryID;
            service.SowAllCity = serviecViewModel.SowAllCity;
            service.Title = serviecViewModel.Title;
            service.Avatar = serviecViewModel.Avatar;
            service.Icon = serviecViewModel.Icon;
            service.Status = serviecViewModel.Status;
        }

        public static void UpdateProvince(this Province province, ProvinceViewModel provinceViewModel)
        {
            province.ID = provinceViewModel.ID;
            province.Name = provinceViewModel.Name;
            province.CityID = provinceViewModel.CityID;
            province.Status = provinceViewModel.Status;
        }

        public static void UpdatePlace(this Place place, PlaceViewModel placeViewModel)
        {
            place.ID = placeViewModel.ID;
            place.Description = placeViewModel.Description;
            place.ServiceID = placeViewModel.ServiceID;
            place.ProvincesID = placeViewModel.ProvincesID;
            place.Tell = placeViewModel.Tell;
            place.Fax = placeViewModel.Fax;
            place.Aderess = placeViewModel.Aderess;
            place.OpenTime = placeViewModel.OpenTime;
            place.ClosingTime = placeViewModel.ClosingTime;
            place.Vote = placeViewModel.Vote;
            place.Website = placeViewModel.Website;
            place.FolderSlider = placeViewModel.FolderSlider;
            place.HomeSlider = placeViewModel.HomeSlider;
            place.Title = placeViewModel.Title;
            place.Avatar = placeViewModel.Avatar;
            place.Icon = placeViewModel.Icon;
            place.Status = placeViewModel.Status;
        }

        public static void UpdateCity(this City city, CityViewModel cityViewModel)
        {
            city.ID = cityViewModel.ID;
            city.Name = cityViewModel.Name;
            city.Status = cityViewModel.Status;
        }
    }
}
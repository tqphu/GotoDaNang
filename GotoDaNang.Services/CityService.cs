using GotoDaNang.Data.Infrastructure;
using GotoDaNang.Data.Repositories;
using GotoDaNang.Model.Model;
using System.Collections.Generic;

namespace GotoDaNang.Services
{
    public interface ICityService
    {
        City Add(City City);

        void Update(City City);

        City Delete(int id);

        IEnumerable<City> GetAll();

        IEnumerable<City> GetAll(string keyword);

        City GetById(int id);

        void Save();
    }

    public class CityService : ICityService
    {
        private ICityRepository _CityRepository;
        private IUnitOfWork _unitOfWork;

        public CityService(ICityRepository CityRepository, IUnitOfWork unitOfWork)
        {
            this._CityRepository = CityRepository;
            this._unitOfWork = unitOfWork;
        }

        public City Add(City City)
        {
            return _CityRepository.Add(City);
        }

        public City Delete(int id)
        {
            return _CityRepository.Delete(id);
        }

        public IEnumerable<City> GetAll()
        {
            return _CityRepository.GetAll();
        }

        public IEnumerable<City> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _CityRepository.GetMulti(x => x.Name.Contains(keyword));
            else
                return _CityRepository.GetAll();
        }

        public City GetById(int id)
        {
            return _CityRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(City City)
        {
            _CityRepository.Update(City);
        }
    }
}
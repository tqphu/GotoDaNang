using GotoDaNang.Data.Infrastructure;
using GotoDaNang.Data.Repositories;
using GotoDaNang.Model.Model;
using System.Collections.Generic;

namespace GotoDaNang.Services
{
    public interface IPlaceService
    {
        Place Add(Place Place);

        void Update(Place Place);

        Place Delete(int id);

        IEnumerable<Place> GetAll();

        IEnumerable<Place> GetAll(string keyword);

        Place GetById(int id);

        void Save();
    }

    public class PlaceService : IPlaceService
    {
        private IPlaceRepository _PlaceRepository;
        private IUnitOfWork _unitOfWork;

        public PlaceService(IPlaceRepository PlaceRepository, IUnitOfWork unitOfWork)
        {
            this._PlaceRepository = PlaceRepository;
            this._unitOfWork = unitOfWork;
        }

        public Place Add(Place Place)
        {
            return _PlaceRepository.Add(Place);
        }

        public Place Delete(int id)
        {
            return _PlaceRepository.Delete(id);
        }

        public IEnumerable<Place> GetAll()
        {
            return _PlaceRepository.GetAll();
        }

        public IEnumerable<Place> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _PlaceRepository.GetMulti(x => x.Title.Contains(keyword));
            else
                return _PlaceRepository.GetAll();
        }

        public Place GetById(int id)
        {
            return _PlaceRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Place Place)
        {
            _PlaceRepository.Update(Place);
        }
    }
}
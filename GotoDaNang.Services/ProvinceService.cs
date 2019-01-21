using GotoDaNang.Data.Infrastructure;
using GotoDaNang.Data.Repositories;
using GotoDaNang.Model.Model;
using System.Collections.Generic;

namespace GotoDaNang.Services
{
    public interface IProvinceService
    {
        Province Add(Province Province);

        void Update(Province Province);

        Province Delete(int id);

        IEnumerable<Province> GetAll();

        IEnumerable<Province> GetAll(string keyword);

        IEnumerable<Province> GetCiTyById(int id);

        Province GetById(int id);

        void Save();
    }

    public class ProvinceService : IProvinceService
    {
        private IProvinceRepository _ProvinceRepository;
        private IUnitOfWork _unitOfWork;

        public ProvinceService(IProvinceRepository ProvinceRepository, IUnitOfWork unitOfWork)
        {
            this._ProvinceRepository = ProvinceRepository;
            this._unitOfWork = unitOfWork;
        }

        public Province Add(Province Province)
        {
            return _ProvinceRepository.Add(Province);
        }

        public Province Delete(int id)
        {
            return _ProvinceRepository.Delete(id);
        }

        public IEnumerable<Province> GetAll()
        {
            return _ProvinceRepository.GetAll();
        }

        public IEnumerable<Province> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _ProvinceRepository.GetMulti(x => x.Name.Contains(keyword));
            else
                return _ProvinceRepository.GetAll();
        }

        public Province GetById(int id)
        {
            return _ProvinceRepository.GetSingleById(id);
        }

        public IEnumerable<Province> GetCiTyById(int id)
        {
            return _ProvinceRepository.GetMulti(x => x.CityID == id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Province Province)
        {
            _ProvinceRepository.Update(Province);
        }
    }
}
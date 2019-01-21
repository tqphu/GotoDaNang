using GotoDaNang.Data.Infrastructure;
using GotoDaNang.Data.Repositories;
using GotoDaNang.Model.Model;
using System.Collections.Generic;

namespace GotoDaNang.Services
{
    public interface IServiceService
    {
        Service Add(Service Service);

        void Update(Service Service);

        Service Delete(int id);

        IEnumerable<Service> GetAll();

        IEnumerable<Service> GetAll(string keyword);

        Service GetById(int id);

        IEnumerable<Service> GetCategoryById(int id);

        void Save();
    }

    public class ServiceService : IServiceService
    {
        private IServiceRepository _ServiceRepository;
        private IUnitOfWork _unitOfWork;

        public ServiceService(IServiceRepository ServiceRepository, IUnitOfWork unitOfWork)
        {
            this._ServiceRepository = ServiceRepository;
            this._unitOfWork = unitOfWork;
        }

        public Service Add(Service Service)
        {
            return _ServiceRepository.Add(Service);
        }

        public Service Delete(int id)
        {
            return _ServiceRepository.Delete(id);
        }

        public IEnumerable<Service> GetAll()
        {
            return _ServiceRepository.GetAll();
        }

        public IEnumerable<Service> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _ServiceRepository.GetMulti(x => x.Title.Contains(keyword));
            else
                return _ServiceRepository.GetAll();
        }

        public Service GetById(int id)
        {
            return _ServiceRepository.GetSingleById(id);
        }

        public IEnumerable<Service> GetCategoryById(int id)
        {
            return _ServiceRepository.GetMulti(x => x.CategoryID == id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Service Service)
        {
            _ServiceRepository.Update(Service);
        }
    }
}
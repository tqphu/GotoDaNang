using GotoDaNang.Data.Infrastructure;
using GotoDaNang.Data.Repositories;
using GotoDaNang.Model.Model;
using System.Collections.Generic;

namespace GotoDaNang.Services
{
    public interface ICategoryService
    {

        Category Add(Category Category);

        void Update(Category Category);

        Category Delete(int id);

        IEnumerable<Category> GetAll();

        IEnumerable<Category> GetAll(string keyword);

        Category GetById(int id);

        void Save();
    }

    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository CategoryRepository, IUnitOfWork unitOfWork)
        {
            this._categoryRepository = CategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public Category Add(Category Category)
        {
            return _categoryRepository.Add(Category);
        }

        public Category Delete(int id)
        {
            return _categoryRepository.Delete(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public IEnumerable<Category> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _categoryRepository.GetMulti(x => x.Title.Contains(keyword));
            else
                return _categoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
            return _categoryRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Category Category)
        {
            _categoryRepository.Update(Category);
        }
    }
}
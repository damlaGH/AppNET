using AppNET.Domain.Entities;
using AppNET.Domain.Interfaces;
using AppNET.Infrastructure;
using AppNET.Infrastructure.IOToTXT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AppNET.App
{
    public class CategoryService : ICategoryService
    {

        private readonly IRepository<Category> _repository;
        public CategoryService()
        {
            _repository=IOCContainer.Resolve<IRepository<Category>>();  //category _repository sine IOCContainerdaki resolve metodu ile kaydettiğimiz her şeyi yüklemiş olduk.
        }
        public void Create(int id, string name)
        {   
            if(string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Kategori adı boş olamaz.");

            var oldCategory = _repository.GetList().FirstOrDefault(c => c.Name == name);
            if (oldCategory != null)
                return;

            Category category = new Category();
            category.Id = id;
            category.Name = name;
            _repository.Add(category);

        }

        public bool Delete(int categoryId)
        {
            return _repository.Remove(categoryId);
        }

        public IReadOnlyCollection<Category> GetAll()
        {
            return _repository.GetList().ToList().AsReadOnly();
        }
        public int GetIdFromName(string categoryName)
        {
            return _repository.GetList().FirstOrDefault(c => c.Name == categoryName).Id;
        }
        public Category GetById(int id)
        {
            return _repository.GetList().FirstOrDefault(c => c.Id == id);
        }


        public Category Update(int categoryId, string newCategoryName)
        {
            if (string.IsNullOrWhiteSpace(newCategoryName))
                throw new ArgumentNullException("Kategori adı boş olamaz.");
            var category= new Category();
            category.Id=categoryId;
            category.Name=newCategoryName;
            return _repository.Update(categoryId, category);
        }
    }
}


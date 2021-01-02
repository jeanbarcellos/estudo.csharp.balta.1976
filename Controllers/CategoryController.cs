using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Models;
using ProductCatalog.Repositories;

namespace ProductCatalog.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryRepository _repository;

        public CategoryController(CategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("v1/categories")]
        [ResponseCache(Duration = 30)]
        public IEnumerable<Category> Get()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("v1/categories/{id}")]
        public Category get(int id)
        {
            return _repository.Get(id);
        }

        [HttpGet]
        [Route("v1/categories/{id}/products")]
        [ResponseCache(Duration = 30)]
        public IEnumerable<Product> GetProducts(int id)
        {
            return _repository.GetProducts(id);
        }

        [HttpPost]
        [Route("v1/categories")]
        public Category Post([FromBody] Category category)
        {
            _repository.Save(category);

            return category;
        }

        [HttpPut]
        [Route("v1/categories")]
        public Category Put([FromBody] Category category)
        {
            _repository.Update(category);

            return category;
        }

        [Route("v1/categories")]
        [HttpDelete]
        public Category Delete([FromBody] Category category)
        {
            _repository.Delete(category);

            return category;
        }


    }

}
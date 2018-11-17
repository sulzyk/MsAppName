using AppName.Logic.Interfaces;
using AppName.Logic.Repositories;
using AppName.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppName.Logic.Products
{
    public class ProductLogic : IProductLogic
    {
        protected IProductRepository Repository { get; set; }

        protected ProductValidator Validator { get; set; }

        public ProductLogic(IProductRepository repository, ProductValidator validator)
        {
            Repository = repository;
            Validator = validator;
        }

        public Result<Product> GetById(int id)
        {
            var product = Repository.GetById(id);

            if (product == null)
            {
                return Result.Error<Product>($"Nie ma protuktu o id {id}.");
            }

            return Result.Ok(product);
        }

        public Result<Product> Add(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("product");
            }

            var validationResult = Validator.Validate(product);

            if (validationResult.IsValid == false)
            {
                return Result.Error<Product>(validationResult.Errors);
            }

            Repository.Add(product);
            Repository.SaveChanges();

            return Result.Ok(product);
        }

        public Result<IQueryable<Product>> GetAllActive()
        {
            return Result.Ok(Repository.GetAllActive());
        }
    }
}

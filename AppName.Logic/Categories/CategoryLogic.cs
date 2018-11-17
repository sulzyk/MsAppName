using AppName.Logic.Interfaces;
using AppName.Logic.Repositories;
using AppName.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppName.Logic.Categories
{
    class CategoryLogic : ICategoryLogic
    {
        protected ICategoryRepository Repository { get; set; }

        public Result<Category> GetById(int id)
        {
            var category = Repository.GetById(id);

            if (category == null)
            {
                return Result.Error<Category>("Brak kategorii");
            }

            return Result.Ok(category);
        }
    }
}

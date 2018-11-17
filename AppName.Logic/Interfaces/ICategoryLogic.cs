using AppName.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppName.Logic.Interfaces
{

    public interface ICategoryLogic : ILogic
    { 
        Result<Category> GetById(int id);

        Result<IQueryable<Category>> GetAllActive();
    }
}

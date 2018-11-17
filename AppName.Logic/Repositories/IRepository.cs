using AppName.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppName.Logic.Repositories
{
    public interface IRepository<T> where T : BaseModel
    {
        void Add(T model);

        void Delete(T model);

        T GetById(int id);

        IQueryable<T> GetAllActive();

        void SaveChanges();
    }
}

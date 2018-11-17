using AppName.Logic.Repositories;
using AppName.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppName.DataAccess
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        protected DataContext Db { get; set; }

        public Repository(DataContext db)
        {
            Db = db;
        }

        public void Add(T model)
        {
            Db.Set<T>().Add(model);
        }

        public void Delete(T model)
        {
            Db.Set<T>().Remove(model);
        }

        public T GetById(int id)
        {
            return Db.Set<T>().FirstOrDefault(m => m.Id == id);
        }

        public IQueryable<T> GetAllActive()
        {
            return Db.Set<T>().Where(m => m.IsActive);
        }

        public void SaveChanges()
        {
            Db.SaveChanges();
        }

    }
}

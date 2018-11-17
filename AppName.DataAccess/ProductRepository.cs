using AppName.Logic.Repositories;
using AppName.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AppName.DataAccess
{
    public  class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DataContext db) :base(db)
        {

        }
        public override IQueryable<Product> GetAllActive()
        {
            return Db.Products
                .Include(p => p.Category)
                .Where(c => c.IsActive);
        }

    }
}

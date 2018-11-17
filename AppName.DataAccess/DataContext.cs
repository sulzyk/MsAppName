using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using AppName.Models;

namespace AppName.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext()
            :base("DefaultConnection")
        {
            
        }

        private string _userName = "system";

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private DateTime _now = DateTime.Now;

        public DateTime Now
        {
            get { return _now; }
            set { _now = value; }
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            ObjectContext ctx = ((IObjectContextAdapter)this).ObjectContext;

            foreach (var entity in ctx.ObjectStateManager.GetObjectStateEntries(EntityState.Modified))
            {
                BaseModel baseObject = entity.Entity as BaseModel;

                if (baseObject == null)
                {
                    continue;
                }

                baseObject.UpdatedDate = Now;
                baseObject.UpdatedUser = UserName;
            }

            foreach (var entity in ctx.ObjectStateManager.GetObjectStateEntries(EntityState.Added))
            {
                BaseModel baseObject = entity.Entity as BaseModel;

                if (baseObject == null)
                {
                    continue;
                }

                baseObject.CreatedDate = Now;
                baseObject.UpdatedDate = Now;
                baseObject.CreatedUser = UserName;
                baseObject.UpdatedUser = UserName;
            }

            return base.SaveChanges();
        }
    }
}
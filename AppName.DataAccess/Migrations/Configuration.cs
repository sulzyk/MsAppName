using AppName.Models;
using Bogus;

namespace AppName.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AppName.DataAccess.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AppName.DataAccess.DataContext context)
        {
            if (context.Categories.Any() == false)
            {
                var categories = new Faker<Category>()
                    .RuleFor(c => c.Name, (f, p) => f.Commerce.Categories(1)[0])
                    .Generate(10);

                context.Categories.AddRange(categories);
            }

            context.SaveChanges();

            if (context.Products.Any() == false)
            {
                var categories = context.Categories.ToList();

                var products = new Faker<Product>()
                    .RuleFor(p => p.Name, (f, p) => f.Commerce.ProductName())
                    .RuleFor(p => p.Category, (f, p) => f.PickRandom(categories))
                    .Generate(10);

                context.Products.AddRange(products);
            }

            context.SaveChanges();
        }
    }
}

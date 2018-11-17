﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppName.DataAccess;
using AppName.Logic.Interfaces;
using AppName.Models;
using AppName.Web.ViewModels.Products;
using AutoMapper;

namespace AppName.Web.Controllers
{
    public class Products1Controller : Controller
    {
        protected IProductLogic Logic { get; set; }

        protected IMapper Mapper { get; set; }

        protected ICategoryLogic CategoryLogic { get; set; }

        public Products1Controller(IProductLogic logic, IMapper mapper, ICategoryLogic categoryLogic)
        {
            Logic = logic;
            Mapper = mapper;
            CategoryLogic = categoryLogic;
        }


        // GET: Products1
        public ActionResult Index()
        {
            using (var db = new DataContext())
            {
                db.Database.Log = log => System.Diagnostics.Debug.WriteLine(log);

                var viewModels = db.Products.Select(p =>
                new ProductViewModel{
                    Id = p.Id,
                    Name = p.Name,
                    Category = p.Category.Name
                })
                    .ToList();

                return View(viewModels);
            }
        }

        public ActionResult Create()
        {
            using (var db = new DataContext())
            {
                var viewModel = new ProductViewModel();

                Supply(viewModel, db);

                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel viewModel)
        {
            if (ModelState.IsValid == false)
            {
                //Supply(viewModel, db);
                return View(viewModel);
            }

            //var product = new Product()
            //{
            //    Name = viewModel.Name,
            //    Price = viewModel.Price,
            //    CategoryId = viewModel.CategoryId
            //};

            var product = Mapper.Map<Product>(viewModel);

            var result = Logic.Add(product);

            if (result.Success == false)
            {

            }

            return RedirectToAction("Index");

        }

        private void Supply(ProductViewModel viewModel,
            DataContext db)
        {

            var categories = CategoryLogic.GetAllActive();

            if (categories.Success)
            {
                viewModel.Categories = categories.Value
                .Select(c => new SelectListItem()
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
                .ToList();
            }
            
        }
    }
}
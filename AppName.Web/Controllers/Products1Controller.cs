using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppName.DataAccess;
using AppName.Logic.Interfaces;
using AppName.Models;
using AppName.Web.Infastructure;
using AppName.Web.ViewModels.Products;
using AutoMapper;
using Syncfusion.JavaScript;
using Syncfusion.JavaScript.DataSources;

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
            //var result = Logic.GetAllActive();

            //var viewModel = Mapper.Map<List<ProductViewModel>>(result.Value.ToList());

            return View();
        }

        public ActionResult DataSource(DataManager dataManager)
        {
            var productsResult = Logic.GetAllActive();

            var operation = new DataOperations();

            var products = operation.Execute(productsResult.Value, dataManager);

            var viewModels = Mapper.Map<List<ProductViewModel>>(products);

            return Json(new
            {
                result = viewModels,
                count = productsResult.Value.Count()
            },JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            var viewModel = new ProductViewModel();

            Supply(viewModel);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel viewModel)
        {
            if (ModelState.IsValid == false)
            {
                Supply(viewModel);
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
                Supply(viewModel);
                result.AddErrorToModelState(ModelState);
                return View(viewModel);
            }

            return RedirectToAction("Index");

        }

        private void Supply(ProductViewModel viewModel)
        {

            var result = CategoryLogic.GetAllActive();

            if (result.Success)
            {
                viewModel.Categories = Mapper.Map<List<SelectListItem>>(result.Value);
            }

        }
    }
}
using AppName.Logic.Interfaces;
using AppName.Logic.Products;
using AppName.Logic.Repositories;
using AppName.Models;
using FluentValidation;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppName.Logic.Test.Products
{
    [TestFixture]
    public class ProductLogicTest
    {
        protected Mock<IProductRepository> Repository { get; set; }
        
        protected Mock<IValidator<Product>> Validator { get; set; }

        protected ProductLogic Create()
        {
            Repository = new Mock<IProductRepository>();

            Validator = new Mock<IValidator<Product>>();

            return new ProductLogic(Repository.Object, Validator.Object);
        }

        [Test]
        public void GetById_Return_Object()
        {
            var logic = Create();

            var product = new Product();

            Repository.Setup(r => r.GetById(It.IsAny<int>()))
                .Returns(product);

            var result = logic.GetById(10);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
            Assert.AreEqual(product, result.Value);

            Repository.Verify(r => r.GetById(10), Times.Once());

        }
        [Test]
        public void GetById_Return_Error_When_Repository_Null()
        {
            var logic = Create();

            var product = new Product();

            Repository.Setup(r => r.GetById(It.IsAny<int>()))
                .Returns((Product)null);

            var result = logic.GetById(10);

            Assert.IsNotNull(result);
            Assert.IsFalse(result.Success);
            Assert.AreEqual(1, result.Errors.Count());

            var error = result.Errors.First();

            Assert.AreEqual(string.Empty, error.PropertyName);
            Assert.AreEqual("Nie ma protuktu o id 10.", error.Message);

            Repository.Verify(r => r.GetById(10), Times.Once());
        }

    }

    
}

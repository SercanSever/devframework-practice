using DevFramework.Core.CrossCuttıngConcerns.Validation.FluentValidation;
using DevFramework.Northwind.Domain.Abstract;
using DevFramework.Northwind.Infrastructure.Concrete;
using DevFramework.Northwind.Service.Abstract;
using DevFramework.Northwind.Service.ValidationRules.FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.Aspects.Postsharp;
using DevFramework.Core.CrossCuttıngConcerns.Caching.Microsoft;
using DevFramework.Core.CrossCuttıngConcerns.Logging.Log4Net.Loggers;
using AutoMapper;

namespace DevFramework.Northwind.Service.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public Product Get(int id)
        {
            return _productDal.Get(x => x.ProductID == id);
        }
        [CacheAspect(typeof(MemoryCacheManager))]
        //[LogAspect(typeof(DatabaseLogger))]   //log.config dosyası gerekiyor.
        [SecurityOperation(Roles = "Admin")]
        public List<Product> GetAll()
        {
            return _productDal.GetList().Select(p => new Product
            {
                CategoryID = p.CategoryID,
                ProductID = p.ProductID,
                ProductName = p.ProductName,
                QuantityPerUnit = p.QuantityPerUnit,
                UnitPrice = p.UnitPrice
            }).ToList();

            //Mapper.Initialize(c =>
            //{
            //    c.CreateMap<Product, Product>();
            //});
            //List<Product> products = Mapper.Map<List<Product>, List<Product>>(_productDal.GetList());
            //return products;
        }
        [FluentValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Product Insert(Product product)
        {
            return _productDal.Add(product);
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Update(Product product)
        {
            return _productDal.Update(product);
        }
    }
}

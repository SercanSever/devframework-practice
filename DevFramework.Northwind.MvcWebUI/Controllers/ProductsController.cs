using DevFramework.Northwind.MvcWebUI.Models;
using DevFramework.Northwind.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFramework.Northwind.MvcWebUI.Controllers
{
    public class ProductsController : Controller
    {
        private IProductService _prodctuService;

        public ProductsController(IProductService prodctuService)
        {
            _prodctuService = prodctuService;
        }

        public ActionResult Index()
        {
            var model = new ProductListViewModel
            {
                Products = _prodctuService.GetAll()
            };
            return View(model);
        }
    }
}
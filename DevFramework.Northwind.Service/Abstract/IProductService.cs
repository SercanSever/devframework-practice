using DevFramework.Northwind.Infrastructure.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Service.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product Get(int id);
        Product Insert(Product product);
        Product Update(Product product);
       
    }
}

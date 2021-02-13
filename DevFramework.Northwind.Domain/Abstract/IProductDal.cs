using DevFramework.Core.DataAccess;
using DevFramework.Core.Entities;
using DevFramework.Northwind.Infrastructure.ComplexTypes;
using DevFramework.Northwind.Infrastructure.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Domain.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        List<ProductDetail> GetProductDetail();
    }
}

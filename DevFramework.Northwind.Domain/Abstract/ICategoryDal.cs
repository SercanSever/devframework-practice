using DevFramework.Core.DataAccess;
using DevFramework.Northwind.Infrastructure.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Domain.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
    }
}

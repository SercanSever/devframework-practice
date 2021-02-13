using DevFramework.Core.DataAccess;
using DevFramework.Core.EntityFramework;
using DevFramework.Northwind.Infrastructure.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Domain.Concrete
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, NorthwindContext>, IEntityRepository<Category>
    {
    }
}

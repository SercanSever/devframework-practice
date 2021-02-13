using DevFramework.Core.EntityFramework;
using DevFramework.Northwind.Domain.Abstract;
using DevFramework.Northwind.Infrastructure.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Domain.Concrete
{
    public class EfUserDal : EfEntityRepositoryBase<User,NorthwindContext>, IUserDal
    {
    }
}

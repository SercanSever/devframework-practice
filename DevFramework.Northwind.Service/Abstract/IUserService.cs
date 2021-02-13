using DevFramework.Northwind.Infrastructure.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Service.Abstract
{
    public interface IUserService
    {
        User GetByUsernameAndPassword(string userName,string password);
    }
}

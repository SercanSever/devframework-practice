using DevFramework.Northwind.Domain.Abstract;
using DevFramework.Northwind.Infrastructure.Concrete;
using DevFramework.Northwind.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Service.Concrete.Managers
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User GetByUsernameAndPassword(string userName, string password)
        {
            return _userDal.Get(x => x.UserName == userName & x.Password == password);
        }
    }
}

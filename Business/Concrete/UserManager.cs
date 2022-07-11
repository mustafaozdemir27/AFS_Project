using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<User> Get(string userName, string password)
        {
            return new SuccessDataResult<User>(_userDal.Get(userName, password));
        }

    }
}

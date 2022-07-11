using System;
using System.Collections.Generic;
using System.Text;
using Business.Utilities.Results;
using Core.Entities;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<User> Get(string username, string password);
    }
}

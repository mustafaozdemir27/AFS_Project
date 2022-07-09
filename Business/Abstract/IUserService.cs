using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<User> Get(string userName, string password);
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserDal
    {
        User Get(string userName ,string password);
    }
}

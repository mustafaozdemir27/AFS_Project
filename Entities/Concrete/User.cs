﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class User:IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserRole UserRole { get; set; }
    }
}

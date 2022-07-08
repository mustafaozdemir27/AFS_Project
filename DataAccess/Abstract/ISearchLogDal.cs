using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ISearchLogDal
    {
        public List<SearchLog> GetAll();

        public List<SearchLog> GetByCriterion(SearchLog entity);
    }
}

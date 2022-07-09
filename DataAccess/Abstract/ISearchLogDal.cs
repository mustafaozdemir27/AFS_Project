using Entities.Concrete;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface ISearchLogDal
    {
         void Add(SearchLog entity);
         List<SearchLog> GetAll();
    }
}

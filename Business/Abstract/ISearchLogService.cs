using Business.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISearchLogService
    {
        IResult Add(SearchLog searchLog);
        IDataResult<List<SearchLog>> GetAll();
    }
}

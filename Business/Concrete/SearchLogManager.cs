using Business.Abstract;
using Business.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class SearchLogManager : ISearchLogService
    {
        ISearchLogDal _searchLogDal;

        public SearchLogManager(ISearchLogDal searchLogDal)
        {
            _searchLogDal = searchLogDal;
        }

        public IResult Add(SearchLog searchLog)
        {
            _searchLogDal.Add(searchLog);
            return new SuccessResult();
        }


        public IDataResult<List<SearchLog>> GetAll()
        {
            return new SuccessDataResult<List<SearchLog>>(_searchLogDal.GetAll());
        }
    }
}

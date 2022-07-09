using Business.Abstract;
using Core.Utilities.Results;
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
            throw new NotImplementedException();
        }


        public IDataResult<List<SearchLog>> GetAll()
        {
            return new SuccessDataResult<List<SearchLog>>(_searchLogDal.GetAll());
        }
    }
}

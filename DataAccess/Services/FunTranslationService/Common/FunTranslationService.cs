using DataAccess.Services.FunTranslationService.Helper;
using DataAccess.Services.FunTranslationService.Interfaces;
using DataAccess.Services.FunTranslationService.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services.FunTranslationService.Common
{
    public class FunTranslationService : IFunTranslationService
    {
        public ResponseModel GetResponse(RequestModel request)
        {
            return RequestHelper.RequestClient<ResponseModel>(Method.POST, "/yoda.json", request);
        }
    }
}

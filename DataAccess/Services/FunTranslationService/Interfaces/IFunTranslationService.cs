using DataAccess.Services.FunTranslationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services.FunTranslationService.Interfaces
{
    public interface IFunTranslationService
    {
        ResponseModel GetResponse(RequestModel request);
    }
}

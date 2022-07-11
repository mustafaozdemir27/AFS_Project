using AFS_Project.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFS_Project.Repositories.Concrete
{
    public class SessionRepository: ISessionRepository
    {
        public void AddSession(string username, string userRole)
        {
            System.Web.HttpContext.Current.Session["UserName"] = username;
            System.Web.HttpContext.Current.Session["UserRole"] = userRole;
        }

        public string GetSessionRole(string userRole)
        {
            return System.Web.HttpContext.Current.Session[userRole].ToString();
        }
    }
}

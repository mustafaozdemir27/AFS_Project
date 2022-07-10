using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFS_Project.Repositories.Implementation
{
    public class SessionRepository: ISessionRepository
    {
        public void AddSession(string username, string role)
        {
            System.Web.HttpContext.Current.Session["UserName"] = username;
            System.Web.HttpContext.Current.Session["Role"] = role;
        }

        public string GetSessionName(string sessionName)
        {
            return System.Web.HttpContext.Current.Session[sessionName].ToString();
        }
    }
}

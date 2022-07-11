using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFS_Project.Repositories.Abstract
{
    public interface ISessionRepository
    {
        void AddSession(string username, string userRole);
    }
}

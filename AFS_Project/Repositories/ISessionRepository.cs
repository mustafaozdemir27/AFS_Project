using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFS_Project.Repositories.Implementation
{
    public interface ISessionRepository
    {
        void AddSession(string username, string role);
        string GetSessionName(string sessionName);
    }
}

using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.ADONET
{
    public class UserDal : IUserDal
    {
        public User Get(string userName, string password)
        {
            User user = null;
            string constr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetUser"))
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = userName;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = password;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {                      
                        sda.Fill(dt);
                    }
                }
            }
            
            if(dt != null && dt.Rows.Count > 0)
            {
                user = new User
                {
                    Id = Convert.ToInt32(dt.Rows[0]["Id"]),
                    Password = dt.Rows[0]["Password"].ToString(),
                    UserName = dt.Rows[0]["Username"].ToString(),
                    UserRole = new UserRole { Id = Convert.ToInt32(dt.Rows[0]["RoleId"]), RoleName = dt.Rows[0]["RoleName"].ToString() }
                };
            }

            return user;
        }
    }
}

using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.ADONET
{
    public class UserImplemantatiton : IUserDal
    {
        public User Get(User entity)
        {
            User user = null;
            string constr = @"Server=(localdb)\mssqllocaldb;Database=Afs_Project_Db;Trusted_Connection=true";
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetUser"))
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = entity.UserName;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = entity.Password;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {                      
                        sda.Fill(dt);
                    }
                }
            }
            
            if(dt != null && dt.Rows.Count > 0)
            {
                user = new User();
                user.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                user.Password = dt.Rows[0]["Password"].ToString();
                user.UserName = dt.Rows[0]["Username"].ToString();
                user.UserRole = new UserRole { Id = Convert.ToInt32(dt.Rows[0]["RoleId"]), RoleName = dt.Rows[0]["RoleName"].ToString()};
            }

            return user;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.ADO
{
    class SearchLogImplementation : ISearchLogDal
    {
        public List<SearchLog> GetAll()
        {
            List<SearchLog> list = new List<SearchLog>();

            string constr = @"Server=(localdb)\mssqllocaldb;Database=Afs_Project_Db;Trusted_Connection=true";
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllSearchLog"))
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }

            foreach(DataRow row in dt.Rows)
            {
                SearchLog log = new SearchLog();
                log.Id = Convert.ToInt32(row["Id"]);
                log.InputText = row["InputText"].ToString();
                log.TranslatedText = row["TranslatedText"].ToString();
                log.TranslationType = row["TranslationType"].ToString();
                log.UserName = row["Username"].ToString();
                log.CreatedDate = Convert.ToDateTime(row["CreatedDate"]);

                list.Add(log);
            }

            return list;
        }

        public List<SearchLog> GetByCriterion(SearchLog entity)
        {
            throw new NotImplementedException();
        }
    }
}

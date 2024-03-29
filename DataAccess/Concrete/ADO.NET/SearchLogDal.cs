﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Configuration;

namespace DataAccess.Concrete.ADONET
{
    public class SearchLogDal : ISearchLogDal
    {
        public void Add(SearchLog entity)
        {

            string constr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("InsertSearchLog"))
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = entity.UserName;
                    cmd.Parameters.Add("@InputText", SqlDbType.VarChar).Value = entity.InputText;
                    cmd.Parameters.Add("@TranslatedText", SqlDbType.VarChar).Value = entity.TranslatedText;
                    cmd.Parameters.Add("@TranslationType", SqlDbType.VarChar).Value = entity.TranslationType;
                    cmd.Parameters.Add("@CreatedDate", SqlDbType.VarChar).Value = entity.CreatedDate;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }
        }

        public List<SearchLog> GetAll()
        {
            List<SearchLog> list = new List<SearchLog>();

            string constr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
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
                log.CreatedDate = row["CreatedDate"].ToString();

                list.Add(log);
            }

            return list;
        }
    }
}

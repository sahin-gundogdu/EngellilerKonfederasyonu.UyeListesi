﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngellilerKonfederasyonu.DAL
{
    public class Helper
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cstr"].ConnectionString);

        public int ExecuteNonQuery(string cmdtext, SqlParameter[] p = null)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(cmdtext, cn);

                if (p != null) cmd.Parameters.AddRange(p);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (cn!=null && cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }

        public SqlDataReader ExecuteReader(string cmdtext, SqlParameter[] p=null)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(cmdtext, cn);
                if (p != null) cmd.Parameters.AddRange(p);

                cn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
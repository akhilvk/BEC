using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace BEC3
{
    class ClsDalRackMaster:ClsCommenConnection 
    {
        //public DataTable dtfill(string query, ClsBllRack obj)
        //{
        //    cmd.Connection = con;
        //    if (con.State == ConnectionState.Closed)
        //    {
        //        con.Open();
        //    }
        //    cmd.CommandText = query;
        //    cmd.Connection = con;
        //    SqlDataAdapter adp = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    adp.Fill(dt);
        //    return dt;
        //}
        public DataTable gridfill(ClsBllRack  objbll, int flag)
        {
            cmd = new SqlCommand("SP1");
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            cmd.Connection = con;
            cmd.Parameters.Add("@flag", SqlDbType.BigInt).Value = flag;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            con.Close();
            return dt;


        }
    }
}
